namespace Template.Lambda;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

using Amazon.DynamoDBv2;

using AmazonLambdaExtension.Serialization;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Template.Lambda.Components.Logging;
using Template.Services;

public sealed class HttpApiServiceResolver
{
    private readonly IServiceProvider provider = BuildProvider();

    private static IServiceProvider BuildProvider()
    {
        var services = new ServiceCollection();

        // Log
        services.AddLogging(c =>
        {
            c.ClearProviders();
            c.AddLambdaLogger();
        });

        // Serializer
        services.AddSingleton<IBodySerializer>(_ => new JsonBodySerializer(new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));

        // Dynamo
        services.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();

        // Http client
        services.AddHttpClient(ConnectorNames.Ipify, c =>
        {
            c.BaseAddress = new Uri("https://api.ipify.org/");
        });

        // Mapper
        services.AddSingleton<IMapper>(_ => new Mapper(new MapperConfiguration(c =>
        {
            c.AddProfile<HttpApiMappingProfile>();
        })));

        // Service
        services.AddSingleton<DataService>();

        return services.BuildServiceProvider();
    }

    public T? GetService<T>()
    {
        return provider.GetService<T>();
    }
}