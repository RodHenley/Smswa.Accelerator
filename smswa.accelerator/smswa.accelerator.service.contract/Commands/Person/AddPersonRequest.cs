using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace smswa.accelerator.service.contract.Commands.Person
{
    public class AddPersonRequest : IRequest
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}
