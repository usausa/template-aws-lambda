namespace Template.Lambda.Functions;

[Lambda]
[ServiceResolver(typeof(ServiceResolver))]
[Filter(typeof(ApiFilter))]
public sealed class MiscFunction
{
    [Api]
    public MiscTimeResponse Time()
    {
        return new MiscTimeResponse { DateTime = DateTime.Now };
    }

    [Api]
    public int Calc(int x, int y)
    {
        return x + y;
    }

    [Api]
    public async ValueTask<MiscHttpResponse> Http([FromServices] IHttpClientFactory httpClientFactory)
    {
        using var client = httpClientFactory.CreateClient(ConnectorNames.Ipify);

        var address = await client.GetStringAsync(string.Empty).ConfigureAwait(false);

        return new MiscHttpResponse { Address = address };
    }
}
