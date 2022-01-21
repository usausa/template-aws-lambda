namespace Template.Components.DynamoDB;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

public class DynamoDBFactory : IDynamoDBFactory
{
    private readonly IAmazonDynamoDB dynamoClient;

    public DynamoDBFactory(IAmazonDynamoDB dynamoClient)
    {
        this.dynamoClient = dynamoClient;
    }

    public IDynamoDBContext Create() => new DynamoDBContext(dynamoClient);
}
