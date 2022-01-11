namespace Template.Lambda.Functions;

using System.Net;
using System.Text.Json;

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

using Template.Lambda.Parameters;

public class ApiFunction
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Function")]
    public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogLine($"Get request. path=[{request.Path}]\n");
        var input = JsonSerializer.Deserialize<ApiGetInput>(request.Body);

        if (String.IsNullOrEmpty(input.Name))
        {
            return new APIGatewayProxyResponse { StatusCode = (int)HttpStatusCode.BadRequest };
        }

        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = JsonSerializer.Serialize(new ApiGetOutput
            {
                Values = Enumerable.Range(1, 5).Select(x => $"{input.Name}-{x}").ToArray()
            }),
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Function")]
    public APIGatewayProxyResponse Post(APIGatewayProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogLine($"Post request. path=[{request.Path}]\n");

        return new APIGatewayProxyResponse { StatusCode = (int)HttpStatusCode.OK };
    }
}
