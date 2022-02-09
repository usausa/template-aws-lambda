namespace Template.Lambda;

using Template.Components.Logging;

public sealed class EventFilter
{
    public void OnFunctionExecuting(ILambdaContext context)
    {
        LambdaLoggerContext.RequestId = context.AwsRequestId;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060", Justification = "Ignore")]
    public void OnFunctionExecuted(ILambdaContext context)
    {
        LambdaLoggerContext.RequestId = null;
    }
}
