namespace Template.Lambda.Functions;

using System;

using Amazon.Lambda.APIGatewayEvents;

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

    public async Task<APIGatewayProxyResponse> Http(APIGatewayProxyRequest request)
    {
        logger.LogInformation("Http request. path=[{Path}]", request.Path);

        using var client = httpClientFactory.CreateClient(ConnectorNames.Ipify);
        var address = await client.GetStringAsync(string.Empty).ConfigureAwait(false);
        return Results.Ok(new MiscHttpOutput { Address = address });
    }

    public APIGatewayProxyResponse Validation(APIGatewayProxyRequest request)
    {
        logger.LogInformation("Validation request. path=[{Path}]", request.Path);

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
