namespace Template.Lambda.Functions;

using Amazon.Lambda.SQSEvents;

public sealed class QueueFunction
{
    private readonly ILogger<QueueFunction> logger;

    public QueueFunction(ILogger<QueueFunction> logger)
    {
        this.logger = logger;
    }

    [LambdaFunction(ResourceName = "Queue", MemorySize = 256, Timeout = 30, Policies = "AWSLambdaBasicExecutionRole")]
    public SQSBatchResponse Handle(SQSEvent sqsEvent)
    {
        var failures = new List<SQSBatchResponse.BatchItemFailure>();
        foreach (var message in sqsEvent.Records)
        {
#pragma warning disable CA1031
            try
            {
                logger.InfoQueueMessageReceived(message.MessageId, message.Body);
            }
            catch (Exception ex)
            {
                logger.ErrorQueueMessageFailed(ex, message.MessageId);
                failures.Add(new SQSBatchResponse.BatchItemFailure { ItemIdentifier = message.MessageId });
            }
#pragma warning restore CA1031
        }

        return new SQSBatchResponse(failures);
    }
}
