namespace Template.Lambda.Functions;

using Amazon.Lambda.Annotations.APIGateway;

using Template.Lambda.Mappers;

public sealed class CrudFunction
{
    private const string Policies = "AWSLambdaBasicExecutionRole, AmazonDynamoDBFullAccess";

    private readonly ILogger<CrudFunction> logger;

    private readonly DataService dataService;

    private readonly TimeProvider timeProvider;

    public CrudFunction(ILogger<CrudFunction> logger, DataService dataService, TimeProvider timeProvider)
    {
        this.logger = logger;
        this.dataService = dataService;
        this.timeProvider = timeProvider;
    }

    [LambdaFunction(ResourceName = "CrudList", MemorySize = 256, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Get, "/crud")]
    public async Task<CrudListResponse> List([FromQuery] string token = "")
    {
        var result = await dataService.QueryDataListAsync(String.IsNullOrEmpty(token) ? null : token, 20).ConfigureAwait(false);

        return new CrudListResponse { Entities = result.List, NextToken = result.Token };
    }

    [LambdaFunction(ResourceName = "CrudGet", MemorySize = 256, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Get, "/crud/{id}")]
    public async Task<IHttpResult> Get(string id)
    {
        var entity = await dataService.QueryDataAsync(id).ConfigureAwait(false);
        return entity is not null ? HttpResults.Ok(entity) : HttpResults.NotFound();
    }

    [LambdaFunction(ResourceName = "CrudCreate", MemorySize = 256, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Post, "/crud")]
    public async Task<CrudCreateResponse> Create([FromBody] CrudCreateRequest request)
    {
        var entity = request.ToEntity();
        entity.Id = Guid.NewGuid().ToString();
        entity.CreatedAt = timeProvider.GetLocalNow().DateTime;

        await dataService.CreateDataAsync(entity).ConfigureAwait(false);

        logger.InfoDataCreated(entity.Id);

        return new CrudCreateResponse { Id = entity.Id };
    }

    [LambdaFunction(ResourceName = "CrudDelete", MemorySize = 256, Timeout = 30, Policies = Policies)]
    [HttpApi(LambdaHttpMethod.Delete, "/crud/{id}")]
    public async Task Delete(string id)
    {
        await dataService.DeleteDataAsync(id).ConfigureAwait(false);

        logger.InfoDataDeleted(id);
    }
}
