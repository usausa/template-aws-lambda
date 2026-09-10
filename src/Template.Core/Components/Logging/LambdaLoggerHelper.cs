namespace Template.Components.Logging;

public static class LambdaLoggerHelper
{
    public static LambdaLoggerProvider CreateProviderByEnvironment()
    {
        var defaultValue = Environment.GetEnvironmentVariable("LogLevel");
        var defaultLevel = !String.IsNullOrEmpty(defaultValue) && Enum.TryParse(defaultValue, out LogLevel result)
            ? result
            : LogLevel.Information;
        var logLevels = Environment.GetEnvironmentVariables()
            .OfType<DictionaryEntry>()
            .Where(static x => (x.Key is string key) && key.StartsWith("LogLevel_", StringComparison.Ordinal))
            .ToDictionary(static x => ((string)x.Key)[9..].Replace('_', '.'), x => Enum.TryParse(x.Value as string, out result) ? result : defaultLevel);
        return new LambdaLoggerProvider(defaultLevel, logLevels.Count == 0 ? null : logLevels);
    }
}
