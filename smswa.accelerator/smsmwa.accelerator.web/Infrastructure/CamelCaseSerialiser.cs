using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace smsmwa.accelerator.web.Infrastructure
{
    public static class CamelCaseSerialiser
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()};
        public static string ToJson(this object item)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(item, Settings);
        }
    }
}
