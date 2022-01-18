namespace Template.Lambda.Functions;

using Amazon.Lambda.APIGatewayEvents;

using Microsoft.Extensions.Logging;

using Template.Lambda.Helpers;
using Template.Lambda.Parameters;

public class ApiFunction
{
    private readonly ILogger<ApiFunction> logger;

    public ApiFunction()
        : this(ServiceLocator.GetService<ILogger<ApiFunction>>())
    {
    }

    public ApiFunction(ILogger<ApiFunction> logger)
    {
        this.logger = logger;
    }

    public APIGatewayProxyResponse Time(APIGatewayProxyRequest request)
    {
        if (request.Headers?.ContainsKey("X-Lambda-Hot-Load") ?? false)
        {
            return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 200 };
        }

        logger.LogInformation("Time request. path=[{Path}]", request.Path);

        return Results.Ok(new ApiTimeOutput { DateTime = DateTime.Now });
    }

    public APIGatewayProxyResponse Bind(APIGatewayProxyRequest request)
    {
        if (request.Headers?.ContainsKey("X-Lambda-Hot-Load") ?? false)
        {
            return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 200 };
        }

        logger.LogInformation("Bind request. path=[{Path}]", request.Path);

        if (request.TryBind<ApiBindInput>(out var input) || String.IsNullOrEmpty(input.Name))
        {
            return Results.BadRequest();
        }

        return Results.Ok(new ApiBindOutput
        {
            Values = Enumerable.Range(1, 5).Select(x => $"{input.Name}-{x}").ToArray()
        });
    }
}
