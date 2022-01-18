namespace Template.Lambda.Functions;

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;

using Xunit;

public class MiscFunctionTest
{
    [Fact]
    public void TestTimeMethod()
    {
        var functions = new MiscFunction();
        var request = new APIGatewayProxyRequest();
        var context = new TestLambdaContext();

        var response = functions.Time(request, context);

        Assert.Equal(200, response.StatusCode);
        Assert.NotEmpty(response.Body);
    }
}
