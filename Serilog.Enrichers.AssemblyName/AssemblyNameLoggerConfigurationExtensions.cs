using Serilog.Configuration;
using Serilog.Enrichers;
using System.Reflection;
using System;

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
      var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
      return enrichmentConfiguration.WithAssemblyName(assembly);
    }

    /// <summary>
    /// Enrich log events with an AssemblyName property containing the current <see cref="AssemblyName.Name"/> of T.
    /// </summary>
    /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithAssemblyName<T>(this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
      var assembly = typeof(T).Assembly;
      return enrichmentConfiguration.WithAssemblyName(assembly);
    }

    /// <summary>
    /// Enrich log events with an AssemblyVersion property containing the current <see cref="AssemblyName.Version"/>.
    /// </summary>
    /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithAssemblyVersion(this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
      var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
      return enrichmentConfiguration.WithAssemblyVersion(assembly);
    }

    /// <summary>
    /// Enrich log events with an AssemblyVersion property containing the current <see cref="AssemblyName.Version"/> of T.
    /// </summary>
    /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration WithAssemblyVersion<T>(this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
      var assembly = typeof(T).Assembly;
      return enrichmentConfiguration.WithAssemblyVersion(assembly);
    }

    static LoggerConfiguration WithAssemblyName(this LoggerEnrichmentConfiguration enrichmentConfiguration, Assembly assembly)
    {
      return enrichmentConfiguration.WithProperty("AssemblyName", assembly.GetName().Name);
    }

    static LoggerConfiguration WithAssemblyVersion(this LoggerEnrichmentConfiguration enrichmentConfiguration, Assembly assembly)
    {
      return enrichmentConfiguration.WithProperty("AssemblyVersion", assembly.GetName().Version);
    }
  }
}