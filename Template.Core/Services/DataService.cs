namespace Template.Services;

using System.Reflection;

using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

using Template.Components.DynamoDB;
using Template.Models;

public class DataService
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

public static class AsyncSearchExtensions
{
    // https://github.com/aws/aws-sdk-net/issues/671
    public static string GetPaginationToken<T>(this AsyncSearch<T> asyncSearch)
    {
        var pi = asyncSearch.GetType().GetProperty("DocumentSearch", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var getter = pi.GetGetMethod(true)!;
        var search = (Search)getter.Invoke(asyncSearch, null)!;
        return search.PaginationToken;
    }
}
