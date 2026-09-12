namespace Template;

using Microsoft.Extensions.Logging.Abstractions;

public static class MockHelper
{
    public static ILogger<T> CreateNullLogger<T>() =>
        new NullLogger<T>();

    public static DataService CreateDataService(IDynamoDBContext dynamoDBContext) =>
        new(new MockDynamoDBFactory(dynamoDBContext));
}
