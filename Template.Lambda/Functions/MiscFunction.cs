namespace Template.Lambda.Functions;

using System;

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

using Microsoft.Extensions.Logging;

using Template.Lambda.Helpers;
using Template.Lambda.Parameters;

public class MiscFunction
{
    private readonly ILogger<MiscFunction> logger;

    private readonly IHttpClientFactory httpClientFactory;

    public MiscFunction()
        : this(ServiceLocator.GetService<ILogger<MiscFunction>>(), ServiceLocator.GetService<IHttpClientFactory>())
    {
    }

    public MiscFunction(ILogger<MiscFunction> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<APIGatewayProxyResponse> Http(APIGatewayProxyRequest request, ILambdaContext context)
    {
        logger.LogInformation("Http request. requestId=[{RequestId}]", context.AwsRequestId);

        using var client = httpClientFactory.CreateClient(ConnectorNames.Ipify);
        var address = await client.GetStringAsync(string.Empty).ConfigureAwait(false);

        return Results.Ok(new MiscHttpOutput { Address = address });
    }

    public APIGatewayProxyResponse Validation(APIGatewayProxyRequest request, ILambdaContext context)
    {
        logger.LogInformation("Validation request. requestId=[{RequestId}]", context.AwsRequestId);

        if (!request.TryBind<MiscValidationInput>(out var input) ||
            !ValidationHelper.Validate(input) ||
            !BindHelper.TryBind(request.Headers, "x", out int x))
        {
            return Results.BadRequest();
        }

        logger.LogDebug("Values input.Value={Value}, x={X}", input.Value, x);

        return Results.Ok();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ignore")]
    public APIGatewayProxyResponse Error()
    {
        throw new InvalidOperationException("Error");
    }
}
