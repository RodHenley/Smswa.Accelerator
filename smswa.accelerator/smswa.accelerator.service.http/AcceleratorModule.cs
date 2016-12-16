using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Metadata;
using Nancy;
using Nancy.ModelBinding;
using smswa.accelerator.data;
using smswa.accelerator.service.contract;
using smswa.accelerator.service.contract.Commands.Person;
using smswa.accelerator.service.contract.Infrastructure;
using smswa.accelerator.service.Handlers.Person;
using smswa.telemetry;

namespace smswa.accelerator.service.http
{
    public class AcceleratorModule:NancyModule
    {
        private readonly IEnumerable<Meta<Lazy<IHandler>>> _handlers;
        private readonly ITelemetry _telemetry;
        public AcceleratorModule(IEnumerable<Meta<Lazy<IHandler>>> handlers, ITelemetry telemetry)
        {
            _handlers = handlers;
            _telemetry = telemetry;

            Get["/"] = x => "Hello World!";
            Get[(typeof(GetPeopleRequest).GetCustomAttribute(typeof(RequestUrlAttribute)) as RequestUrlAttribute).Url, true] = async (x, ct) => await Resolve<GetPeopleRequest>();
            Get["/Person/{Id}", true] = async (x, ct) => await Resolve<GetPersonRequest>();

            Post["/Person", true] = async (x, ct) => await Resolve<AddPersonRequest>();
            Post["/Person/{PersonId}/Address", true] = async (x, ct) => await Resolve<AddAddressRequest>();
            Post["/Person/{PersonId}/Contact", true] = async (x, ct) => await Resolve<AddContactRequest>();
        }

        async Task<dynamic> Resolve<T>() where T:IRequest
        {
            return await _telemetry.LogAndTimeOperation(
                async () => await resolveHandler(typeof (T).Name).Handle(this.Bind<T>()), 
                typeof(T).Name,
                null, null
                );
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
