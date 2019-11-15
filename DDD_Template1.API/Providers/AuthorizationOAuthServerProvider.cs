using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Mirabeu.API.Providers
{
    public class AuthorizationOAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                if (!property.Key.StartsWith("."))
                {
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
                }
            }

            return base.TokenEndpoint(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Acess-Control-Allow-Origin", new[] { "*" });

            var validated = CreateClaimsIdentity(context.UserName, context.Password);

            if (validated)
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

                var props = new AuthenticationProperties();

                var ticket = new AuthenticationTicket(Thread.CurrentPrincipal.Identity as ClaimsIdentity, props);

                context.Validated(ticket);
            }

            return Task.FromResult(validated);
        }

        public bool CreateClaimsIdentity(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                var claimsIdentity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

                claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, username));

                var principal = new GenericPrincipal(claimsIdentity, null);
                Thread.CurrentPrincipal = principal;

                return true;
            }

            return false;
        }
    }
}