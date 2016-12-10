using NUnit.Framework;
using Shuttle.Core.Infrastructure;
using SimpleInjector;
using Lifestyle = Shuttle.Core.Infrastructure.Lifestyle;

namespace Shuttle.Core.SimpleInjector.Tests
{
    [TestFixture]
    public class SimpleInjectorComponentContainerFixture
    {
        [Test]
        public void Should_be_able_to_register_and_resolve_a_type()
        {
            var container = new SimpleInjectorComponentContainer(new Container());
            var serviceType = typeof(IDoSomething);
            var implementationType = typeof(DoSomething);
            var bogusType = typeof(object);

            container.Register(serviceType, implementationType, Lifestyle.Singleton);

            Assert.NotNull(container.Resolve(serviceType));
            Assert.AreEqual(implementationType, container.Resolve(serviceType).GetType());
            Assert.Throws<TypeResolutionException>(() => container.Resolve(bogusType));
        }

        [Test]
        public void Should_be_able_to_use_constructor_injection()
        {
            var container = new SimpleInjectorComponentContainer(new Container());
            var serviceType = typeof(IDoSomething);
            var implementationType = typeof(DoSomethingWithDependency);

            container.Register(serviceType, implementationType, Lifestyle.Singleton);

            var someDependency = new SomeDependency();

            container.Register(typeof(ISomeDependency), someDependency);

            Assert.AreSame(someDependency, container.Resolve<IDoSomething>().SomeDependency);
        }
    }
}