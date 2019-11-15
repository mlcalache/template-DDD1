using DDD_Template1.Application.Services;
using DDD_Template1.Domain.Interfaces.Container;
using DDD_Template1.Domain.Interfaces.Notifications;
using DDD_Template1.Domain.Interfaces.Services;
using DDD_Template1.Domain.Notifications;
using DDD_Template1.Infra.Service.AirportList;
using SimpleInjector;

namespace DDD_Template1.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootstrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IAirportListService, AirportListService>(Lifestyle.Scoped);
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<IAirportExhibitionService, AirportExhibitionService>(Lifestyle.Scoped);
            container.Register<IDomainContainer, DomainContainer>(Lifestyle.Scoped);
            container.Register<IDomainNotificationHandler, DomainNotificationHandler>(Lifestyle.Scoped);
        }
    }
}