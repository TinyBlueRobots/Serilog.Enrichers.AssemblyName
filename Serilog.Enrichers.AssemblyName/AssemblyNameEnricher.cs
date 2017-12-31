using System;
using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
  class AssemblyNameEnricher : ILogEventEnricher
  {
    private readonly string _value;
    readonly string _propertyName;

    public AssemblyNameEnricher(string propertyName, Func<AssemblyName, string> propertyValue)
    {
      _value = propertyValue(Assembly.GetEntryAssembly().GetName());
      _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
      logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(_propertyName, _value));
    }
  }
}
