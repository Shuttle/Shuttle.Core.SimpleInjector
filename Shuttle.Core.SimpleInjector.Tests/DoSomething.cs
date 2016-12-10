namespace Shuttle.Core.SimpleInjector.Tests
{
    public class DoSomething : IDoSomething
    {
        public ISomeDependency SomeDependency {
            get { return null; }
        }
    }
}