namespace Template.Lambda.Functions;

using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

using Template.Lambda.Parameters;

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
    public async Task TestUpdate()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.SetupLoad<DataEntity?>(new DataEntity { Id = "x", Name = "old", Version = 1 });

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Update("x", new CrudUpdateRequest { Name = "new", Version = 1 });

        Assert.Equal(HttpStatusCode.OK, output.StatusCode);
        var saved = Assert.IsType<DataEntity>(Assert.Single(mockDynamoDBContext.SavedObjects));
        Assert.Equal("new", saved.Name);
    }

    [Fact]
    public async Task TestUpdateNotFound()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.SetupLoad<DataEntity?>(default);

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Update("x", new CrudUpdateRequest { Name = "new", Version = 1 });

        Assert.Equal(HttpStatusCode.NotFound, output.StatusCode);
    }

    [Fact]
    public async Task TestUpdateVersionMismatch()
    {
        var mockDynamoDBContext = new MockDynamoDBContext();
        mockDynamoDBContext.SetupLoad<DataEntity?>(new DataEntity { Id = "x", Name = "old", Version = 2 });
        mockDynamoDBContext.SetupSaveFailure(new ConditionalCheckFailedException("The conditional request failed"));

        var lambda = new CrudFunction(
            MockHelper.CreateNullLogger<CrudFunction>(),
            MockHelper.CreateDataService(mockDynamoDBContext),
            TimeProvider.System);

        var output = await lambda.Update("x", new CrudUpdateRequest { Name = "new", Version = 1 });

        Assert.Equal(HttpStatusCode.PreconditionFailed, output.StatusCode);
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
