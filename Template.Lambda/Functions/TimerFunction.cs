namespace Template.Lambda.Functions;

using Microsoft.Extensions.Logging;

public class TimerFunction
{
    private readonly ILogger<TimerFunction> logger;

    public TimerFunction()
        : this(ServiceLocator.CreateLogger<TimerFunction>())
    {
    }

    public TimerFunction(ILogger<TimerFunction> logger)
    {
        this.logger = logger;
    }

    public void Handle()
    {
        logger.LogInformation("Timer event raised.");
    }
}
