using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ghtk.Authorization
{
    public class XClientSourceAuthenticationHandle : AuthenticationHandler<XClientSourceAuthenticationHandlerOptions>
    {
        public XClientSourceAuthenticationHandle(IOptionsMonitor<XClientSourceAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var clientSource = Context.Request.Headers["X-Client-Source"];
            if (clientSource == 0)
            {
                return Task.FromResult(AuthenticateResult.Fail("X-Client-Source header is missing."));
            }

            var clientSourceValue = clientSource.FirstOrDefault();
            if (clientSourceValue == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Multiple X-Client-Source headers are not allowed."));
            }

            if(!Options.ValidateClientSource(clientSourceValue))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid client source."));
            }

            var identity = new ClaimsIdentity(Scheme.Name);
            identity.AddClaim(new Claim(ClaimTypes.Name, clientSourceValue));
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
