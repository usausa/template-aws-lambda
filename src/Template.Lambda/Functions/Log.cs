namespace Template.Lambda.Functions;

using Microsoft.Extensions.Logging;

#pragma warning disable SYSLIB1006
internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Information, Message = "Data created. id=[{id}]")]
    public static partial void InfoDataCreated(this ILogger logger, string id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Data updated. id=[{id}]")]
    public static partial void InfoDataUpdated(this ILogger logger, string id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Data deleted. id=[{id}]")]
    public static partial void InfoDataDeleted(this ILogger logger, string id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Timer event raised.")]
    public static partial void InfoTimerEventRaised(this ILogger logger);

    [LoggerMessage(Level = LogLevel.Information, Message = "Queue message received. id=[{id}], body=[{body}]")]
    public static partial void InfoQueueMessageReceived(this ILogger logger, string id, string body);

    [LoggerMessage(Level = LogLevel.Error, Message = "Queue message failed. id=[{id}]")]
    public static partial void ErrorQueueMessageFailed(this ILogger logger, Exception ex, string id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Notification received. subject=[{subject}], message=[{message}]")]
    public static partial void InfoNotificationReceived(this ILogger logger, string subject, string message);
}
#pragma warning restore SYSLIB1006
