using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.service.contract;

namespace smsmwa.accelerator.web.Infrastructure
{
    public class WcfService
    {
        public async Task<TResponse> Execute<TRequest, TResponse>(TRequest request)
            where TRequest:IRequest 
            where TResponse: class, IResponse
        {
            return await ChannelFactory<IService>.CreateChannel(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:61461/service.svc")
                ).Execute(request) as TResponse;
        }
    }
}
