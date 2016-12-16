using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.service.contract.Infrastructure;

namespace smswa.accelerator.service.contract.Commands.Person
{
    [RequestUrl("/Person/{id}/Address")]
    public class AddAddressRequest: IParamertisedRequest
    {
        public int PersonId { get; set; }
        public int AddressTypeId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ToRequestString()
        {
            return (GetType().GetTypeInfo().GetCustomAttribute(typeof(RequestUrlAttribute)) as RequestUrlAttribute)
                .Url
                .Replace("{id}", PersonId.ToString());
        }
    }
}
