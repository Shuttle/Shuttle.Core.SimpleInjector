using NUnit.Framework;
using Shuttle.Core.ComponentContainer.Tests;
using SimpleInjector;

namespace Shuttle.Core.SimpleInjector.Tests
{
    [TestFixture]
    public class SimpleInjectorComponentContainerFixture : ComponentContainerFixture
    {
        [Test]
        public void Should_be_able_resolve_all_instances()
        {
            var container = new SimpleInjectorComponentContainer(new Container());

            RegisterCollection(container);
            ResolveCollection(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_a_singleton()
        {
            var container = new SimpleInjectorComponentContainer(new Container());

            RegisterSingleton(container);
            ResolveSingleton(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_transient_components()
        {
            var container = new SimpleInjectorComponentContainer(new Container());

            RegisterTransient(container);
            ResolveTransient(container);
        }
    }
}