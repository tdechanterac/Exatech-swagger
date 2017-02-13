using System;
using System.Collections.Generic;
using System.Linq;
using Exatech.Swagger.Core;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Exatech.Swagger.Startup))]

namespace Exatech.Swagger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

	    private void ConfigureAuth(IAppBuilder app) {
		    app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
				Authority = "http://auth.exatech.com/api/oauth/dialog",
				RequiredScopes = new[] { "read", "write" },
			});

		    app.UseApiKeyAuthentication(new ApiKeyAuthenticationOption {});
	    }
    }
}
