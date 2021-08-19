using DDD_Template1.API.AutoMapper;
using DDD_Template1.Infra.CrossCutting.IoC;
using Microsoft.Practices.ServiceLocation;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace DDD_Template1.API
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            SimpleInjectorBootstrapper.RegisterServices(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocator(container));

            var mapper = AutoMapperConfig.CreateMapperConfiguration();

            container.RegisterSingleton(mapper);

            container.Register(() => mapper.CreateMapper(container.GetInstance), Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next();
                }
            });
        }
    }
}