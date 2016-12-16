using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;

namespace smswa.accelerator.service.App_Code
{
    public class Startup
    {
        public static void AppInitialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>();
            builder.RegisterModule<Module>();
            AutofacHostFactory.Container = builder.Build();
        }
    }
}