namespace Template.Mock;

using Amazon.DynamoDBv2.DataModel;

using Template.Components.DynamoDB;

public sealed class MockDynamoDBFactory : IDynamoDBFactory
{
    private readonly IDynamoDBContext dynamoDBContext;

    public MockDynamoDBFactory(IDynamoDBContext dynamoDBContext)
    {
        this.dynamoDBContext = dynamoDBContext;
    }

    public IDynamoDBContext Create() => dynamoDBContext;
}
