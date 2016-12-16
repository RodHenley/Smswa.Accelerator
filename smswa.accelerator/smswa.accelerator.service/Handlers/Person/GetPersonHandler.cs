using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.data;
using smswa.accelerator.sample.model;
using smswa.accelerator.service.contract;
using smswa.accelerator.service.contract.Commands.Person;

namespace smswa.accelerator.service.Handlers.Person
{
    public class GetPersonHandler:IHandler<GetPersonRequest, GetPersonResponse>, IHandler
    {
        private readonly AcceleratorContext _context;

        public GetPersonHandler(AcceleratorContext context)
        {
            _context = context;
        }

        public async Task<GetPersonResponse> Handle(GetPersonRequest request)
        {
            var person = await _context.Persons
                .Select(p=>new contract.Commands.Person.Person {
                    Id = p.Id,
                    Name = p.Firstname + " " + p.Surname,
                    HomeAddress = p.Addresses
                        .Where(a =>
                            a.AddressTypeId == (int)AddressTypes.Home
                            && !a.Inactive
                            )
                            .Select(a=> a.Line1 + ", " + a.Suburb)
                        .FirstOrDefault(),
                    PrimaryContact = p.Contacts
                        .Where(a =>
                            //a.ContactTypeId == (int)ContactTypes.PersonalEmail  &&
                            !a.Inactive
                            )
                        .OrderByDescending(a => a.Id)
                        .Select(a => a.Value)
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (person == null)
            {
                return new GetPersonResponse
                {
                    Success = false,
                    Errors = new[]{"NotFound"}
                };
            }

            return new GetPersonResponse
            {
                Success = true,
                Errors = new string[] {},
                Person = person
            };
        }

        public async Task<IResponse> Handle(IRequest request)
        {
            return await Handle(request as GetPersonRequest);
        }
    }
}
