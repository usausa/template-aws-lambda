namespace Template;

using Microsoft.Extensions.Logging.Abstractions;

using Template.Lambda;

public static class MockHelper
{
    public static ILogger<T> CreateNullLogger<T>() =>
        new NullLogger<T>();

    public static IMapper CreateHttpApiMapper() =>
        new Mapper(new MapperConfiguration(static c => c.AddProfile<ApiMappingProfile>()));

    public static DataService CreateDataService(IDynamoDBContext dynamoDBContext) =>
        new(new MockDynamoDBFactory(dynamoDBContext));
}
