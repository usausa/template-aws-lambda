namespace Template.Lambda.Functions;

public sealed class CrudFunctionTest
{
    [Fact]
    public async Task TestGet()
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
