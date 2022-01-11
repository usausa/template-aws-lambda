namespace Template.Lambda.Helpers;

using System.Text.Json;

using Amazon.Lambda.APIGatewayEvents;

public static class RequestExtensions
{
    public static T Bind<T>(this APIGatewayProxyRequest request) =>
        JsonSerializer.Deserialize<T>(request.Body, SerializerOptions.Default);
}
