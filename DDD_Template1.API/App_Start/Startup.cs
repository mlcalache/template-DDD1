using Gedof.API;
using Microsoft.Owin.Security.OAuth;
using DDD_Template1.Infra.CrossCutting.Helpers;
using Mirabeu.API.Providers;
using Owin;
using System;

namespace DDD_Template1.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorInitializer.Initialize(app);
            ConfigureOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            double hours = 1;
            double.TryParse(ConfigurationManagerHelper.AccessTokenExpirationMinutes, out hours);

            var OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(hours),
                Provider = new AuthorizationOAuthServerProvider()
            };
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}