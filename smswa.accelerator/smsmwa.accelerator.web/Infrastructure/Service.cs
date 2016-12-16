using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using smswa.accelerator.service.contract;
using smswa.accelerator.service.contract.Infrastructure;

namespace smsmwa.accelerator.web.Infrastructure
{
    public class Service
    {
        private readonly string _baseAddress;

        public Service(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public async Task<TResponse> Execute<TRequest,TResponse>(HttpMethod method, TRequest request)
        {
            using (var client = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress),
            })
            {
                string endpoint;

                if (typeof (IParamertisedRequest).IsAssignableFrom(typeof (TRequest)))
                {
                    endpoint = (request as IParamertisedRequest).ToRequestString();
                }
                else
                {
                    endpoint = (typeof(TRequest)
                    .GetCustomAttribute(typeof(RequestUrlAttribute)) as RequestUrlAttribute)
                    .Url;

                }

                HttpResponseMessage response;
                if (method == HttpMethod.Post)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json")); 
                    response = await client.PostAsync(endpoint, content);
                }
                else
                {
                    client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json")); 
                    response = await client.GetAsync(endpoint);
                }

                var responseString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseString);
            }
        }
    }
}
