namespace Template.Lambda.Functions;

[Lambda]
[ServiceResolver(typeof(ServiceResolver))]
[Filter(typeof(EventFilter))]
public sealed class TimerFunction
{
    private readonly ILogger<TimerFunction> logger;

    public TimerFunction(ILogger<TimerFunction> logger)
    {
        this.logger = logger;
    }

    [Event]
    public void Tick()
    {
        logger.LogInformation("Timer event raised.");
    }
}
