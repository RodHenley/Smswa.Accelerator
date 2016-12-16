using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.service.contract.Infrastructure;

namespace smswa.accelerator.service.contract.Commands.Person
{
    [RequestUrl("/Person/{id}/Contact")]
    public class AddContactRequest: IParamertisedRequest
    {
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }
        public string ToRequestString()
        {
            return (GetType().GetTypeInfo().GetCustomAttribute(typeof(RequestUrlAttribute)) as RequestUrlAttribute)
                .Url
                .Replace("{id}", PersonId.ToString());
        }
    }
}
