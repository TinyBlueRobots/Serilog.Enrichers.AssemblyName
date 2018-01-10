# Serilog.Enrichers.AssemblyName

Enriches Serilog events with information from the assembly.

[![NuGet Version](http://img.shields.io/nuget/v/Serilog.Enrichers.AssemblyName.svg?style=flat)](https://www.nuget.org/packages/Serilog.Enrichers.AssemblyName/)

To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.AssemblyName
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithAssemblyName()
    .Enrich.WithAssemblyVersion()
    // ...other configuration...
    .CreateLogger();
```

The `WithAssemblyName()` enricher will add an `AssemblyName` property to produced events.

The `WithAssemblyVersion()` enricher will add an `AssemblyVersion` property to produced events.

The assembly is determined by `Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly()`. If you need to specify the assembly, you can provide a type using `WithAssemblyName<T>()`.

To use semantic versioning, `{version.Major}.{version.Minor}.{version.Build}`, then call `WithAssemblyVersion(true)`.