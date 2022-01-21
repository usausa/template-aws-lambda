namespace Template.Lambda.Functions;

using Amazon.DynamoDBv2.DataModel;

using Moq;

using Template.Models;

using Xunit;

public sealed class CrudFunctionTest
{
    [Fact]
    public async ValueTask TestGet()
    {
        var mockDynamoDBContext = new Mock<IDynamoDBContext>();
        mockDynamoDBContext
            .Setup(x => x.LoadAsync<DataEntity?>(It.IsAny<string>(), default))
            .Returns(Task.FromResult<DataEntity?>(default));

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateHttpApiMapper(),
            MockHelper.CreateDataService(mockDynamoDBContext.Object));

        var output = await lambda.Get("x").ConfigureAwait(false);

        Assert.Null(output);
    }
}
