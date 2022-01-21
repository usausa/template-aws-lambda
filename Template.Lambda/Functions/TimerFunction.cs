namespace Template.Lambda.Functions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Template.Components.Logging;

public class TimerFunction
{
    private readonly ILogger<TimerFunction> logger;

    public TimerFunction()
    {
        // TODO
        var provider = new ServiceCollection()
            .AddLogging(c =>
            {
                c.ClearProviders();
                c.AddProvider(LambdaLoggerHelper.CreateProviderByEnvironment());
            })
            .BuildServiceProvider();
        logger = provider.GetRequiredService<ILogger<TimerFunction>>();
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
