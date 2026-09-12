namespace Template.Lambda;

using Amazon.DynamoDBv2;

using Microsoft.Extensions.DependencyInjection;

using Template.Components.DynamoDB;
using Template.Components.Logging;
using Template.Components.Setting;

[LambdaStartup]
public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Log
        services.AddLogging(static c =>
        {
            c.ClearProviders();
            c.AddProvider(LambdaLoggerHelper.CreateProviderByEnvironment());
        });

        // System
        services.AddSingleton(TimeProvider.System);

        // Setting
        services.AddSingleton<ISetting, EnvironmentSetting>();

        // Dynamo
        services.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
        services.AddSingleton<IDynamoDBFactory, DynamoDBFactory>();

        // Http client
        services.AddHttpClient(ConnectorNames.Ipify, static c =>
        {
            c.BaseAddress = new Uri("https://api.ipify.org/");
        });

        // Service
        services.AddSingleton<DataService>();
    }
}
