using Serilog.Configuration;
using Serilog.Enrichers;
using System.Reflection;

namespace Serilog
{
  /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers for <see cref="AssemblyName"/>.
    /// capabilities.
    /// </summary>
  public static class AssemblyNameLoggerConfigurationExtensions
  {
    /// <summary>
    /// Enrich log events with an AssemblyName property containing the current <see cref="AssemblyName.Name"/>.
    /// </summary>
    /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithAssemblyName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
      return enrichmentConfiguration.With(new AssemblyNameEnricher("AssemblyName", assemblyName => assemblyName.Name));
    }

    /// <summary>
    /// Enrich log events with an AssemblyVersion property containing the current <see cref="AssemblyName.Version"/>.
    /// </summary>
    /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithAssemblyVersion(this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
      return enrichmentConfiguration.With(new AssemblyNameEnricher("AssemblyVersion", assemblyName => assemblyName.Version.ToString()));
    }
  }
}