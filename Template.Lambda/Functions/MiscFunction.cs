namespace Template.Lambda.Functions;

using System;

using AmazonLambdaExtension.Annotations;

using Template.Lambda.Parameters;

[Lambda]
[ServiceResolver(typeof(ServiceResolver))]
[Filter(typeof(HttpApiFilter))]
public sealed class MiscFunction
{
    [HttpApi]
    public MiscTimeResponse Time()
    {
        return new MiscTimeResponse { DateTime = DateTime.Now };
    }

    [HttpApi]
    public int Calc(int x, int y)
    {
        return x + y;
    }

    [HttpApi]
    public async ValueTask<MiscHttpResponse> Http([FromServices] IHttpClientFactory httpClientFactory)
    {
        using var client = httpClientFactory.CreateClient(ConnectorNames.Ipify);

        var address = await client.GetStringAsync(string.Empty).ConfigureAwait(false);

        return new MiscHttpResponse { Address = address };
    }
}
