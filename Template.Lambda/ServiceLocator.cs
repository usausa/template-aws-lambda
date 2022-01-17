namespace Template.Lambda;

using System.Collections;

using Microsoft.Extensions.DependencyInjection;

using Template.Lambda.Components.Logging;

using Microsoft.Extensions.Logging;

public static class ServiceLocator
{
    private static readonly Lazy<IServiceProvider> Provider = new(() =>
    {
        var services = new ServiceCollection();
        Startup(services);
        return services.BuildServiceProvider();
    });

    private static readonly Lazy<LambdaLoggerFactory> LoggerFactory = new(() =>
    {
        var defaultValue = Environment.GetEnvironmentVariable("LogLevel");
        var defaultLevel = !String.IsNullOrEmpty(defaultValue) && Enum.TryParse(defaultValue, out LogLevel result)
            ? result
            : LogLevel.Information;
        var logLevels = Environment.GetEnvironmentVariables()
            .OfType<DictionaryEntry>()
            .Where(x => (x.Key is string key) && key.StartsWith("LogLevel_", StringComparison.Ordinal))
            .ToDictionary(x => ((string)x.Key)[9..].Replace('_', '.'), x => Enum.TryParse(x.Value as string, out result) ? result : defaultLevel);

        return new LambdaLoggerFactory(defaultLevel, logLevels.Count == 0 ? null : logLevels);
    });

    public static LambdaLoggerFactory ResolveLoggerFactory() => LoggerFactory.Value;

    public static ILogger<T> CreateLogger<T>() => ResolveLoggerFactory().CreateLogger<T>();

    private static void Startup(IServiceCollection services)
    {
        services.AddHttpClient(ConnectorNames.Ipify, c =>
        {
            c.BaseAddress = new Uri("https://api.ipify.org/");
        });
    }

    public static IHttpClientFactory ResolveHttpClientFactory() => Provider.Value.GetRequiredService<IHttpClientFactory>();
}
