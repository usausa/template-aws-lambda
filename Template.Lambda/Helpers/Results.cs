namespace Template.Lambda.Helpers;

using System.Net;
using System.Text.Json;

using Amazon.Lambda.APIGatewayEvents;

public static class Results
{
    private static readonly Dictionary<string, string> JsonResultHeader = new()
    {
        { "Content-Type", "application/json" }
    };

    public static APIGatewayProxyResponse Ok<T>(T response) => new()
    {
        StatusCode = (int)HttpStatusCode.OK,
        Body = JsonSerializer.Serialize(response, SerializerOptions.Default),
        Headers = JsonResultHeader
    };

    public static APIGatewayProxyResponse Ok() => new()
    {
        StatusCode = (int)HttpStatusCode.OK
    };

    public static APIGatewayProxyResponse BadRequest() => new()
    {
        StatusCode = (int)HttpStatusCode.BadRequest
    };

    public static APIGatewayProxyResponse NotFound() => new()
    {
        StatusCode = (int)HttpStatusCode.NotFound
    };
}
