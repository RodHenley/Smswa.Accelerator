using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using smswa.accelerator.service.contract;

namespace smswa.accelerator.service
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<smswa.accelerator.data.Module>();

            builder.RegisterType<smswa.telemetry.NoOpTelemetry>()
                .As<smswa.telemetry.ITelemetry>()
                .SingleInstance();

            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => t.Name.EndsWith("Handler"))
                .As(typeof(IHandler))
                .WithMetadata("CommandName", t => t.GetTypeInfo().ImplementedInterfaces.First(i => i.Name == "IHandler`2").GenericTypeArguments[0].Name)
                .InstancePerDependency()
                ;

        }
    }
}
