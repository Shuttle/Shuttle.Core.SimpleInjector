﻿namespace Shuttle.Core.SimpleInjector.Tests
{
    public class DoSomethingWithDependency : IDoSomething
    {
        public ISomeDependency SomeDependency { get; private set; }

        public DoSomethingWithDependency(ISomeDependency someDependency)
        {
            SomeDependency = someDependency;
        }
    }
}