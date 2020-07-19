using NUnit.Framework;
using Shuttle.Core.Container.Tests;

namespace Shuttle.Core.SimpleInjector.Tests
{
    [TestFixture]
    public class SimpleInjectorComponentContainerFixture : ContainerFixture
    {
        [Test]
        public void Should_be_able_to_resolve_all_instances()
        {
            var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

            RegisterCollection(container);
            ResolveCollection(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_a_singleton()
        {
            var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

            RegisterSingleton(container);
            ResolveSingleton(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_transient_components()
        {
            var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

            RegisterTransient(container);
            ResolveTransient(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_an_open_generic_singleton()
        {
            var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

            RegisterSingletonGeneric(container);
            ResolveSingletonGeneric(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_transient_open_generic_components()
        {
            var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

            RegisterTransientGeneric(container);
            ResolveTransientGeneric(container);
        }

		[Test]
		public void Should_be_able_to_register_and_resolve_a_multiple_singleton()
		{
			var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

			RegisterMultipleSingleton(container);
			ResolveMultipleSingleton(container);
		}

		[Test]
		public void Should_be_able_to_register_and_resolve_multiple_transient_components()
		{
			var container = new SimpleInjectorComponentContainer(new global::SimpleInjector.Container());

			RegisterMultipleTransient(container);
			ResolveMultipleTransient(container);
		}
	}
}