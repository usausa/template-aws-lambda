namespace Template.Services;

public sealed class DataService
{
    private readonly IDynamoDBFactory dynamoDBFactory;

    public DataService(IDynamoDBFactory dynamoDBFactory)
    {
        this.dynamoDBFactory = dynamoDBFactory;
    }

    public async ValueTask<(List<DataEntity> List, string? Token)> QueryDataListAsync(string? paginationToken, int limit)
    {
        using var context = dynamoDBFactory.Create();
        var table = context.GetTargetTable<DataEntity>();
        var search = table.Scan(new ScanOperationConfig
        {
            PaginationToken = paginationToken,
            Limit = limit
        });

        var list = await search.GetNextSetAsync().ConfigureAwait(false);
        var entities = context.FromDocuments<DataEntity>(list).ToList();
        var nextToken = search.IsDone ? null : search.PaginationToken;

        return (entities, nextToken);
    }

    public async ValueTask<DataEntity?> QueryDataAsync(string id)
    {
        using var context = dynamoDBFactory.Create();
        return await context.LoadAsync<DataEntity>(id).ConfigureAwait(false);
    }

    public async ValueTask CreateDataAsync(DataEntity entity)
    {
        using var context = dynamoDBFactory.Create();
        await context.SaveAsync(entity).ConfigureAwait(false);
    }

    public async ValueTask DeleteDataAsync(string id)
    {
        using var context = dynamoDBFactory.Create();
        await context.DeleteAsync<DataEntity>(id).ConfigureAwait(false);
    }
}
