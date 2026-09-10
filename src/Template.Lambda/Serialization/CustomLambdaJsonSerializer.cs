namespace Template.Lambda.Serialization;

using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Unicode;

using Amazon.Lambda.Serialization.SystemTextJson;

using Template.Components.Json;

public sealed class CustomLambdaJsonSerializer : DefaultLambdaJsonSerializer
{
    public CustomLambdaJsonSerializer()
        : base(static options =>
        {
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            options.Converters.Add(new DateTimeConverter());
        })
    {
    }
}
