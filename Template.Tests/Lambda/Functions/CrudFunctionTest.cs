namespace Template.Lambda.Functions;

public sealed class CrudFunctionTest
{
    [Fact]
    public async Task TestGet()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.SetupLoad<DataEntity?>(default);

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateHttpApiMapper(),
            MockHelper.CreateDataService(mockDynamoDBContext));

        var output = await lambda.Get("x").ConfigureAwait(false);

        Assert.Null(output);
    }
}
