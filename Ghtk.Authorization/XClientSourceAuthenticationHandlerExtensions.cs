using Microsoft.AspNetCore.Authentication;

namespace Ghtk.Authorization
{
    public static class XClientSourceAuthenticationHandlerExtensions
    {
        public static AuthenticationBuilder AddXClientSourceAuthentication(this AuthenticationBuilder builder, Action<XClientSourceAuthenticationHandlerOptions> configureOptions)
        {
            return builder.AddScheme<XClientSourceAuthenticationHandlerOptions, XClientSourceAuthenticationHandle>("X-Client-Source", configureOptions);
        }
    } 
}
