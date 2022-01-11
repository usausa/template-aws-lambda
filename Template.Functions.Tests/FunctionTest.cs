namespace Template.Functions.Tests;

using Amazon.Lambda.TestUtilities;

using Xunit;

public class FunctionTest
{
    [Fact]
    public void TestGetMethod()
    {
        var functions = new Functions();
        var request = new GetRequest { Name = "Test" };
        var context = new TestLambdaContext();

        var response = functions.Get(request, context);

        Assert.NotNull(response);
        Assert.NotEmpty(response!.Values);
    }
}
