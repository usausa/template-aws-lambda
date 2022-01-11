namespace Template.Functions;

using System.Diagnostics.CodeAnalysis;

using Amazon.Lambda.Core;

public class GetRequest
{
    public string? Name { get; set; }
}

public class GetResponse
{
    [AllowNull]
    public string[] Values { get; set; }
}

public class Functions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Function")]
    public GetResponse? Get(GetRequest request, ILambdaContext context)
    {
        context.Logger.LogLine("Get Request\n");

        if (String.IsNullOrEmpty(request.Name))
        {
            return null;
        }

        return new GetResponse
        {
            Values = Enumerable.Range(1, 5).Select(x => $"{request.Name}-{x}").ToArray()
        };
    }
}
