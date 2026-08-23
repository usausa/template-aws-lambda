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
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Get("x");

        Assert.NotNull(output);
    }
}
