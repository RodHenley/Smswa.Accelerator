using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.data;
using smswa.accelerator.service.contract;
using smswa.accelerator.service.contract.Commands.Person;

namespace smswa.accelerator.service.Handlers.Person
{
    public class AddPersonHandler:IHandler,IHandler<AddPersonRequest,AddPersonResponse>
    {
        private readonly AcceleratorContext _context;

        public AddPersonHandler(AcceleratorContext context)
        {
            _context = context;
        }

        public async Task<IResponse> Handle(IRequest request)
        {
            return await Handle(request as AddPersonRequest);
        }

        public async Task<AddPersonResponse> Handle(AddPersonRequest request)
        {
            var person = DtoToModel(request);

            try
            {

                person = _context.Persons.Add(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new AddPersonResponse
                {
                    Success = false,
                    Errors = new[] { e.Message }
                };
            }

            return new AddPersonResponse
            {
                Id = person.Id,
                Success = true,
                Errors = new string[] {}
            };
        }

        private static sample.model.Person DtoToModel(AddPersonRequest request)
        {
            return new sample.model.Person
            {
                Firstname = request.Firstname,
                Surname = request.Surname
            };
        }
    }
}
