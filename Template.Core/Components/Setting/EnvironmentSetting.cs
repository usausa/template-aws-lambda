namespace Template.Components.Setting;

public sealed class EnvironmentSetting : ISetting
{
    public string? GetValue(string key) => Environment.GetEnvironmentVariable(key);
}
