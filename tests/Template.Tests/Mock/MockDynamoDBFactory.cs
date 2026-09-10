namespace Template.Mock;

public sealed class MockDynamoDBFactory : IDynamoDBFactory
{
    private readonly IDynamoDBContext dynamoDBContext;

    public MockDynamoDBFactory(IDynamoDBContext dynamoDBContext)
    {
        this.dynamoDBContext = dynamoDBContext;
    }

    public IDynamoDBContext Create() => dynamoDBContext;
}
