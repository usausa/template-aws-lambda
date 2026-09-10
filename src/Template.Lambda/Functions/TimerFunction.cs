namespace Template.Lambda.Functions;

public sealed class TimerFunction
{
    private readonly ILogger<TimerFunction> logger;

    public TimerFunction(ILogger<TimerFunction> logger)
    {
        this.logger = logger;
    }

    [LambdaFunction(ResourceName = "Timer", MemorySize = 128, Timeout = 30, Policies = "AWSLambdaBasicExecutionRole")]
    public void Tick()
    {
        logger.InfoTimerEventRaised();
    }
}
