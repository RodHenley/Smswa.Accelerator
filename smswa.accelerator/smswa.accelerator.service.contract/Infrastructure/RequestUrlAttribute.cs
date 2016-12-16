using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smswa.accelerator.service.contract.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequestUrlAttribute:Attribute
    {
        public string Url { get; private set; }

        public RequestUrlAttribute(string url)
        {
            Url = url;
        }
    }
}
