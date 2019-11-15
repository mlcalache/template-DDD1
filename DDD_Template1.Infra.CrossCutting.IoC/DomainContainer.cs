using DDD_Template1.Domain.Interfaces.Container;
using SimpleInjector;
using System.Collections.Generic;
using System.Linq;

namespace DDD_Template1.Infra.CrossCutting.IoC
{
    public class DomainContainer : IDomainContainer
    {
        #region Private vars

        private readonly Container _container;

        #endregion Private vars

        #region Ctors

        public DomainContainer(Container container)
        {
            _container = container;
        }

        #endregion Ctors

        #region Public methods

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return _container.GetAllInstances(typeof(TService)).Cast<TService>();
        }

        public TService GetInstance<TService>()
        {
            return (TService)_container.GetInstance(typeof(TService));
        }

        #endregion Public methods
    }
}