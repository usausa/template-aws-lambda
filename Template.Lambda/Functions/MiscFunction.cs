namespace Template.Lambda.Functions;

using Amazon.Lambda.Annotations.APIGateway;

public sealed class MiscFunction
{
    private const string Policies = "AWSLambdaBasicExecutionRole";

    private readonly TimeProvider timeProvider;

    public MiscFunction(TimeProvider timeProvider)
    {
        this.timeProvider = timeProvider;
    }

    [LambdaFunction(ResourceName = "MiscTime", MemorySize = 128, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Get, "/misc/time")]
    public MiscTimeResponse Time()
    {
        return new MiscTimeResponse { DateTime = timeProvider.GetLocalNow().DateTime };
    }

    [LambdaFunction(ResourceName = "MiscCalc", MemorySize = 128, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Get, "/misc/calc")]
    public int Calc([FromQuery] int x, [FromQuery] int y)
    {
        return x + y;
    }

    [LambdaFunction(ResourceName = "MiscHttp", MemorySize = 256, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Get, "/misc/http")]
    public async Task<MiscHttpResponse> Http([FromServices] IHttpClientFactory httpClientFactory)
    {
        using var client = httpClientFactory.CreateClient(ConnectorNames.Ipify);

        var address = await client.GetStringAsync(string.Empty).ConfigureAwait(false);

        return new MiscHttpResponse { Address = address };
    }
}
