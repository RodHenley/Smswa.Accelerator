using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace smswa.accelerator.data
{
    public class Module:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //this ensures a static reference to EF.SqlServer - otherwise this is excluded from the build output
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            var connectionString = ConfigurationManager.ConnectionStrings["accelerator"];
            builder.RegisterType<AcceleratorContext>()
                .AsSelf()
                .WithParameter("connectionString", connectionString.ConnectionString)
                .InstancePerLifetimeScope();
        }
    }
}
