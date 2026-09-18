namespace Template.Lambda.Functions;

using Amazon.DynamoDBv2.DocumentModel;

public sealed class CrudFunctionTests
{
    [Fact]
    public async Task TestGet()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.SetupLoad<DataEntity?>(default);

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Get("x");

        Assert.NotNull(output);
    }

    [Fact]
    public async Task TestDelete()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.Table.SetupDeleteItem(new Document { ["Id"] = "x" });

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Delete("x");

        Assert.Equal(HttpStatusCode.OK, output.StatusCode);
    }

    [Fact]
    public async Task TestDeleteNotFound()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.Table.SetupDeleteItem([]);

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Delete("x");

        Assert.Equal(HttpStatusCode.NotFound, output.StatusCode);
    }
}
