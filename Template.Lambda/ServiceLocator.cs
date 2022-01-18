namespace Template.Lambda;

using System.Collections;

using Amazon.DynamoDBv2;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Template.Lambda.Components.Logging;
using Template.Services;

public static class ServiceLocator
{
    private static readonly IServiceProvider Provider = BuildProvider();

    private static IServiceProvider BuildProvider()
    {
        var services = new ServiceCollection();

        // Log
        services.AddLogging(c =>
        {
            c.ClearProviders();
            c.AddProvider(CreateLoggerProvider());
        });

        // Dynamo
        services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient());

        // Http client
        services.AddHttpClient(ConnectorNames.Ipify, c =>
        {
            c.BaseAddress = new Uri("https://api.ipify.org/");
        });

        // Mapper
        services.AddSingleton<IMapper>(_ => new Mapper(new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        })));

        // Service
        services.AddSingleton<DataService>();

        return services.BuildServiceProvider();
    }

    private static ILoggerProvider CreateLoggerProvider()
    {
        var defaultValue = Environment.GetEnvironmentVariable("LogLevel");
        var defaultLevel = !String.IsNullOrEmpty(defaultValue) && Enum.TryParse(defaultValue, out LogLevel result)
            ? result
            : LogLevel.Information;
        var logLevels = Environment.GetEnvironmentVariables()
            .OfType<DictionaryEntry>()
            .Where(x => (x.Key is string key) && key.StartsWith("LogLevel_", StringComparison.Ordinal))
            .ToDictionary(x => ((string)x.Key)[9..].Replace('_', '.'), x => Enum.TryParse(x.Value as string, out result) ? result : defaultLevel);

        return new LambdaLoggerProvider(defaultLevel, logLevels.Count == 0 ? null : logLevels);
    }

    public static T GetService<T>()
        where T : notnull
    {
        return Provider.GetRequiredService<T>();
    }
}
