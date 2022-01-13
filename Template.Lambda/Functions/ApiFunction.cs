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

    public APIGatewayProxyResponse Time(APIGatewayProxyRequest request)
    {
        logger.LogInformation("Time request. path=[{Path}]", request.Path);

        return Results.Ok(new ApiTimeOutput { DateTime = DateTime.Now });
    }

    public APIGatewayProxyResponse Bind(APIGatewayProxyRequest request)
    {
        logger.LogInformation("Bind request. path=[{Path}]", request.Path);

        var input = request.Bind<ApiBindInput>();

        if (String.IsNullOrEmpty(input.Name))
        {
            return Results.BadRequest();
        }

        return Results.Ok(new ApiBindOutput
        {
            Values = Enumerable.Range(1, 5).Select(x => $"{input.Name}-{x}").ToArray()
        });
    }
}
