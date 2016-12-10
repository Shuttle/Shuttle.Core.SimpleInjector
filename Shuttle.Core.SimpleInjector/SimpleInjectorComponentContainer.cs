using System;
using Shuttle.Core.Infrastructure;
using SimpleInjector;
using Lifestyle = Shuttle.Core.Infrastructure.Lifestyle;

namespace Shuttle.Core.SimpleInjector
{
    public class SimpleInjectorComponentContainer : IComponentRegistry, IComponentResolver
    {
        private readonly Container _container;

        public SimpleInjectorComponentContainer(Container container)
        {
            Guard.AgainstNull(container, "container");

            _container = container;
        }

        public IComponentRegistry Register(Type serviceType, Type implementationType, Lifestyle lifestyle)
        {
            Guard.AgainstNull(serviceType, "serviceType");
            Guard.AgainstNull(implementationType, "implementationType");

            try
            {
                switch (lifestyle)
                {
                    case Lifestyle.Transient:
                    {
                        _container.Register(serviceType, implementationType, global::SimpleInjector.Lifestyle.Transient);

                        break;
                    }
                    default:
                    {
                        _container.Register(serviceType, implementationType, global::SimpleInjector.Lifestyle.Singleton);

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new TypeRegistrationException(ex.Message, ex);
            }

            return this;
        }

        public IComponentRegistry Register(Type serviceType, object instance)
        {
            Guard.AgainstNull(serviceType, "serviceType");
            Guard.AgainstNull(instance, "instance");

            try
            {
                _container.RegisterSingleton(serviceType, () => instance);
            }
            catch (Exception ex)
            {
                throw new TypeRegistrationException(ex.Message, ex);
            }

            return this;
        }

        public object Resolve(Type serviceType)
        {
            Guard.AgainstNull(serviceType, "serviceType");

            try
            {
                return _container.GetInstance(serviceType);
            }
            catch (Exception ex)
            {
                throw new TypeResolutionException(ex.Message, ex);
            }
        }
    }
}