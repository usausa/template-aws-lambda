namespace Template.Lambda.Functions;

using System.Text.Json;

using Amazon.Lambda.APIGatewayEvents;

using Template.Lambda.Parameters;

using Xunit;

public class ApiFunctionTest
{
    [Fact]
    public void TestBindMethod()
    {
        var functions = new ApiFunction();
        var request = new APIGatewayProxyRequest
        {
            Body = JsonSerializer.Serialize(new ApiBindInput { Name = "Test" })
        };

        var response = functions.Bind(request);

        Assert.Equal(200, response.StatusCode);
        Assert.NotEmpty(response.Body);
    }
}
