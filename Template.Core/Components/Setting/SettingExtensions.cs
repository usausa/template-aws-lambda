namespace Template.Components.Setting;

public static class SettingExtensions
{
    public static T GetValue<T>(this ISetting setting, string key)
    {
        var value = setting.GetValue(key);
        return value is not null && Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture) is T result ? result : default!;
    }
}
