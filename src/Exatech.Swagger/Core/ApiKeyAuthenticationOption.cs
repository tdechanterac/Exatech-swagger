using Microsoft.Owin.Builder;
using Owin;

namespace Exatech.Swagger.Core {
	///Example
	public class ApiKeyAuthenticationOption {
	}

	public class IdentityServerBearerTokenAuthenticationOptions {
		public string Authority { get; set; }
		public string[] RequiredScopes { get; set; }
	}

	public static class AppbuilderExtensions {
		public static void UseApiKeyAuthentication(this IAppBuilder appbuilder, ApiKeyAuthenticationOption options) {
			
		}
		public static void UseIdentityServerBearerTokenAuthentication(this IAppBuilder appbuilder, IdentityServerBearerTokenAuthenticationOptions options) {

		}
	}
}