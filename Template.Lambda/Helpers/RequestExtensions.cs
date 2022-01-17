namespace Template.Lambda.Helpers;

using System.Text.Json;

using Amazon.Lambda.APIGatewayEvents;

public static class RequestExtensions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Ignore")]
    public static bool TryBind<T>(this APIGatewayProxyRequest request, out T value)
    {
        try
        {
            value = JsonSerializer.Deserialize<T>(request.Body, SerializerOptions.Default);
            return true;
        }
        catch (Exception)
        {
            value = default!;
            return false;
        }
    }
}
