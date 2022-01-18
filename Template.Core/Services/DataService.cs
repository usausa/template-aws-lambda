namespace Template.Services;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

using Template.Models;

public class DataService
{
    private readonly IAmazonDynamoDB dynamoClient;

    public DataService(IAmazonDynamoDB dynamoClient)
    {
        this.dynamoClient = dynamoClient;
    }

    public async ValueTask<DataEntity?> QueryDataAsync(string id)
    {
        using var dynamo = new DynamoDBContext(dynamoClient);
        return await dynamo.LoadAsync<DataEntity>(id).ConfigureAwait(false);
    }

    public async ValueTask CreateDataAsync(DataEntity entity)
    {
        using var dynamo = new DynamoDBContext(dynamoClient);
        await dynamo.SaveAsync(entity).ConfigureAwait(false);
    }

    public async ValueTask DeleteDataAsync(string id)
    {
        using var dynamo = new DynamoDBContext(dynamoClient);
        await dynamo.DeleteAsync<DataEntity>(id).ConfigureAwait(false);
    }
}
