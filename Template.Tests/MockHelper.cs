namespace Template;

using Amazon.DynamoDBv2.DataModel;

using AutoMapper;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Template.Lambda;
using Template.Mock;
using Template.Services;

public static class MockHelper
{
    public static ILogger<T> CreateNullLogger<T>() =>
        new NullLogger<T>();

    public static IMapper CreateHttpApiMapper() =>
        new Mapper(new MapperConfiguration(c => c.AddProfile<HttpApiMappingProfile>()));

    public static DataService CreateDataService(IDynamoDBContext dynamoDBContext) =>
        new(new MockDynamoDBFactory(dynamoDBContext));
}
