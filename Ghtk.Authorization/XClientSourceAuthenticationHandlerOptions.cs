using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Ghtk.Authorization
{
    public class XClientSourceAuthenticationHandlerOptions : AuthenticationSchemeOptions
    {
        public Func<string, SecurityToken, ClaimsPrincipal, bool> ClientValidator { get; set; } = (clienSource, token, principal) => false; 
        public string IssuerSigningKey { get; set; } = string.Empty;
    }
}
