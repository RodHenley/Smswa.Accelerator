using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nancy;
using Nancy.Bootstrappers.Autofac;

namespace smswa.accelerator.service.http.Infrastructure
{
    public class AutofacBootstrapper:AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            existingContainer.Update(
                builder =>
                {
                    builder.RegisterModule<smswa.accelerator.service.Module>();
                }
                );
        }

    }
}
