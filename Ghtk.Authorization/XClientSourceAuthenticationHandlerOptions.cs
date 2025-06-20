using Microsoft.AspNetCore.Authentication;

namespace Ghtk.Authorization
{
    public class XClientSourceAuthenticationHandlerOptions : AuthenticationSchemeOptions
    {
        public Func<string?, bool> ValidateClientSource { get; set; } = (clienSource) => false; 
    }
}
