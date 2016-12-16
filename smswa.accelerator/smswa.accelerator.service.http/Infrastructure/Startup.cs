using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace smswa.accelerator.service.http.Infrastructure
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }

    }
}
