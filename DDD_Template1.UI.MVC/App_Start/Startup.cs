using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace DDD_Template1.UI.MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorInitializer.Initialize();
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ExpireTimeSpan = TimeSpan.FromMinutes(60),
                CookieName = "DDD_Template1Cookie",
                AuthenticationType = CookieAuthenticationDefaults.CookiePrefix,
                LoginPath = new PathString("/Account/Index"),
                ReturnUrlParameter = "url"
            });
        }
    }
}