namespace Template.Lambda.Functions;

using Amazon.Lambda.SNSEvents;

public sealed class NotificationFunction
{
    private readonly ILogger<NotificationFunction> logger;

    public NotificationFunction(ILogger<NotificationFunction> logger)
    {
        this.logger = logger;
    }

    [LambdaFunction(ResourceName = "Notification", MemorySize = 128, Timeout = 30, Policies = "AWSLambdaBasicExecutionRole")]
    public void Handle(SNSEvent snsEvent)
    {
        foreach (var record in snsEvent.Records)
        {
            logger.InfoNotificationReceived(record.Sns.Subject, record.Sns.Message);
        }
    }
}
