namespace Template.Lambda.Functions;

using Amazon.Lambda.APIGatewayEvents;

using Microsoft.Extensions.Logging;

using Template.Lambda.Helpers;
using Template.Lambda.Parameters;

public class ApiFunction
{
    private readonly ILogger<ApiFunction> logger;

    public ApiFunction()
        : this(ServiceLocator.CreateLogger<ApiFunction>())
    {
    }

    public ApiFunction(ILogger<ApiFunction> logger)
    {
        this.logger = logger;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Function")]
    public APIGatewayProxyResponse Get(APIGatewayProxyRequest request)
    {
        logger.LogInformation("Get request. path=[{Path}]", request.Path);

        var input = request.Bind<ApiGetInput>();

        if (String.IsNullOrEmpty(input.Name))
        {
            return Results.BadRequest();
        }

        return Results.Ok(new ApiGetOutput
        {
            Values = Enumerable.Range(1, 5).Select(x => $"{input.Name}-{x}").ToArray()
        });
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Function")]
    public APIGatewayProxyResponse Post(APIGatewayProxyRequest request)
    {
        logger.LogInformation("Post request. path=[{Path}]", request.Path);

        return Results.Ok();
    }
}
