using System.Collections.Generic;

namespace DDD_Template1.Domain.Interfaces.Container
{
    public interface IDomainContainer
    {
        IEnumerable<TService> GetAllInstances<TService>();

        TService GetInstance<TService>();
    }
}