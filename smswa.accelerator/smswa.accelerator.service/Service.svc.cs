﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.Metadata;
using smswa.accelerator.service.contract;

namespace smswa.accelerator.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private readonly IEnumerable<Meta<Lazy<IHandler>>> _handlers;

        public Service(IEnumerable<Meta<Lazy<IHandler>>> handlers)
        {
            _handlers = handlers;
        }

        public string HealthCheck()
        {
            return "OK";
        }

        public async Task<IResponse> Execute(IRequest request)
        {
            var handler = resolveHandler(request.GetType().Name);
            return await handler.Handle(request);
        }

        IHandler resolveHandler(string handler)
        {
            return _handlers
                    .First(h => h.Metadata["CommandName"].ToString() == handler)
                    .Value
                    .Value;
        }
    }
}
