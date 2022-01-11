namespace Template.Lambda.Helpers;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

using Template.Lambda.Components.Json;

public static class SerializerOptions
{
    public static JsonSerializerOptions Default { get; }

    static SerializerOptions()
    {
        Default = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            IgnoreNullValues = true,
        };
        Default.Converters.Add(new DateTimeConverter());
    }
}
