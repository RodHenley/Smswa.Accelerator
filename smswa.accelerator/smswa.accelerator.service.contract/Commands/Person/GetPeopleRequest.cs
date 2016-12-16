using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.service.contract.Infrastructure;

namespace smswa.accelerator.service.contract.Commands.Person
{
    [RequestUrl("/Person")]
    public class GetPeopleRequest:IRequest
    {
    }
}
