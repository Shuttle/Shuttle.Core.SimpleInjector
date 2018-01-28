using System;
using System.Collections.Generic;
using System.Linq;
using Shuttle.Core.Container;
using Shuttle.Core.Contract;
using Lifestyle = Shuttle.Core.Container.Lifestyle;

namespace Shuttle.Core.SimpleInjector
{
    public class SimpleInjectorComponentContainer : ComponentRegistry, IComponentResolver
    {
        private readonly global::SimpleInjector.Container _container;

        public SimpleInjectorComponentContainer(global::SimpleInjector.Container container)
        {
            Guard.AgainstNull(container, "container");

            _container = container;
        }

        public override IComponentRegistry Register(Type dependencyType, Type implementationType, Lifestyle lifestyle)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");
            Guard.AgainstNull(implementationType, "implementationType");

	        base.Register(dependencyType, implementationType, lifestyle);

            try
            {
                switch (lifestyle)
                {
                    case Lifestyle.Transient:
                        {
                            _container.Register(dependencyType, implementationType, global::SimpleInjector.Lifestyle.Transient);

                            break;
                        }
                    default:
                        {
                            _container.Register(dependencyType, implementationType, global::SimpleInjector.Lifestyle.Singleton);

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

        public override IComponentRegistry RegisterCollection(Type dependencyType, IEnumerable<Type> implementationTypes, Lifestyle lifestyle)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");
            Guard.AgainstNull(implementationTypes, "implementationTypes");

	        base.RegisterCollection(dependencyType, implementationTypes, lifestyle);

            try
            {
                switch (lifestyle)
                {
                    case Lifestyle.Transient:
                        {
                            _container.RegisterCollection(dependencyType, implementationTypes.Select(t => global::SimpleInjector.Lifestyle.Transient.CreateRegistration(t, _container)));

                            break;
                        }
                    default:
                        {
                            _container.RegisterCollection(dependencyType, implementationTypes.Select(t => global::SimpleInjector.Lifestyle.Singleton.CreateRegistration(t, _container)));
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

        public override IComponentRegistry RegisterInstance(Type dependencyType, object instance)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");
            Guard.AgainstNull(instance, "instance");

	        base.RegisterInstance(dependencyType, instance);

            try
            {
                _container.RegisterSingleton(dependencyType, () => instance);
            }
            catch (Exception ex)
            {
                throw new TypeRegistrationException(ex.Message, ex);
            }

            return this;
        }

        public override IComponentRegistry RegisterGeneric(Type dependencyType, Type implementationType, Lifestyle lifestyle)
        {
            return Register(dependencyType, implementationType, lifestyle);
        }

        public object Resolve(Type dependencyType)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");

            try
            {
                return _container.GetInstance(dependencyType);
            }
            catch (Exception ex)
            {
                throw new TypeResolutionException(ex.Message, ex);
            }
        }

        public IEnumerable<object> ResolveAll(Type dependencyType)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");

            try
            {
                return _container.GetAllInstances(dependencyType);
            }
            catch (Exception ex)
            {
                throw new TypeResolutionException(ex.Message, ex);
            }
        }
    }
}