using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smswa.accelerator.service.contract.Commands.Person
{
    public class GetPersonResponse:IResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public Person Person { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string PrimaryContact { get; set; }

    }
}
