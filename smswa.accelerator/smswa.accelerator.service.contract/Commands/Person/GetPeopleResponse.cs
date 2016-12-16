using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smswa.accelerator.service.contract.Commands.Person
{
    public class GetPeopleResponse:IResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public ListPerson[] People { get; set; }
    }

    public class ListPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
