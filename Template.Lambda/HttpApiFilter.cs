namespace Template.Lambda;

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

using Template.Components.Logging;

public sealed class HttpApiFilter
{
    public APIGatewayProxyResponse? OnFunctionExecuting(APIGatewayProxyRequest request, ILambdaContext context)
    {
        if (request.Headers?.ContainsKey("X-Lambda-Ping") ?? false)
        {
            return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 200 };
        }

        LambdaLoggerContext.RequestId = context.AwsRequestId;

        return null;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060", Justification = "Ignore")]
    public void OnFunctionExecuted(APIGatewayProxyRequest request, ILambdaContext context)
    {
        LambdaLoggerContext.RequestId = null;
    }
}
