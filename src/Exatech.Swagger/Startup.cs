using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Exatech.Swagger.Startup))]

namespace Exatech.Swagger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
//            ConfigureAuth(app);
        }
    }
}
