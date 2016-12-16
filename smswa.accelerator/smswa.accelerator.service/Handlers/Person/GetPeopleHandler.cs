using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using smswa.accelerator.data;
using smswa.accelerator.service.contract;
using smswa.accelerator.service.contract.Commands.Person;

namespace smswa.accelerator.service.Handlers.Person
{
    public class GetPeopleHandler:IHandler,IHandler<GetPeopleRequest,GetPeopleResponse>
    {
        private readonly AcceleratorContext _context;

        public GetPeopleHandler(AcceleratorContext context)
        {
            _context = context;
        }

        public async Task<IResponse> Handle(IRequest request)
        {
            return await Handle(request as GetPeopleRequest);
        }

        public async Task<GetPeopleResponse> Handle(GetPeopleRequest request)
        {
            var people = await _context.Persons
                .Select(p => new ListPerson
                {
                    Id = p.Id,
                    Name = p.Firstname + " " + p.Surname,
                })
                .ToArrayAsync();
            return new GetPeopleResponse
            {
                Errors = new string[] {},
                Success = true,
                People = people
            };
        }
    }
}