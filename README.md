# Shuttle.Core.SimpleInjector

> **Warning**
> This package has been deprecated in favour of [.NET Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).

```
PM> Install-Package Shuttle.Core.SimpleInjector
```

The `SimpleInjectorComponentContainer` implements both the `IComponentRegistry` and `IComponentResolver` interfaces.  

``` c#
var container = new SimpleInjectorComponentContainer(new SimpleInjector.Container());
```

