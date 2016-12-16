using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using smsmwa.accelerator.web.Controllers;
using smsmwa.accelerator.web.Infrastructure;
using smswa.telemetry;
using smswa.telemetry.appinsights;

namespace smsmwa.accelerator.web
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            var httpContext = ConfigurationManager.AppSettings["HttpServiceUrl"];

            builder.RegisterType<PersonController>()
                .WithParameter(new TypedParameter(typeof(string), httpContext))
                .InstancePerRequest();

            builder.RegisterType<Service>()
                .AsSelf();

            var telemetry = new AppInsightsTelemetry();
            builder.RegisterInstance(telemetry)
                .As<ITelemetry>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
