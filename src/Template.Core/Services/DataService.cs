namespace Template.Services;

using Amazon.DynamoDBv2.Model;

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
        var search = table.Query(new QueryOperationConfig
        {
            IndexName = DataEntity.ListIndexName,
            Filter = new QueryFilter(nameof(DataEntity.Kind), QueryOperator.Equal, DataEntity.DefaultKind),
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

    // Saves only when the stored Version equals the one the caller saw. The item is loaded first so that
    // the attributes not in the request (Kind, CreatedAt) are kept.
    public async ValueTask<(DataUpdateStatus Status, DataEntity? Entity)> UpdateDataAsync(string id, string name, int version)
    {
        using var context = dynamoDBFactory.Create();
        var entity = await context.LoadAsync<DataEntity>(id).ConfigureAwait(false);
        if (entity is null)
        {
            return (DataUpdateStatus.NotFound, null);
        }

        entity.Name = name;
        entity.Version = version;
        try
        {
            await context.SaveAsync(entity).ConfigureAwait(false);
            return (DataUpdateStatus.Success, entity);
        }
        catch (ConditionalCheckFailedException)
        {
            return (DataUpdateStatus.VersionMismatch, null);
        }
    }

    public async ValueTask<bool> DeleteDataAsync(string id)
    {
        using var context = dynamoDBFactory.Create();
        var table = context.GetTargetTable<DataEntity>();
        var document = await table.DeleteItemAsync(id, new DeleteItemOperationConfig { ReturnValues = ReturnValues.AllOldAttributes }).ConfigureAwait(false);
        return document.Count > 0;
    }
}
