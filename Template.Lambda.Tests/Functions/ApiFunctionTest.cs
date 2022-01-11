namespace Template.Lambda.Functions;

using System.Text.Json;

using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;

using Xunit;

public class ApiFunctionTest
{
    [Fact]
    public void TestGetMethod()
    {
        var functions = new ApiFunction();
        var request = new APIGatewayProxyRequest
        {
            Body = JsonSerializer.Serialize(new ApiGetInput { Name = "Test" })
        };
        var context = new TestLambdaContext();

        var response = functions.Get(request, context);

        Assert.Equal(200, response.StatusCode);
        Assert.NotEmpty(response.Body);
    }
}
