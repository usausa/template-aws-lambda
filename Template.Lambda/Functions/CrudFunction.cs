namespace Template.Lambda.Functions;

[Lambda]
[ServiceResolver(typeof(ServiceResolver))]
[Filter(typeof(ApiFilter))]
public sealed class CrudFunction
{
    private readonly ILogger<CrudFunction> logger;

    private readonly IMapper mapper;

    private readonly DataService dataService;

    public CrudFunction(ILogger<CrudFunction> logger, IMapper mapper, DataService dataService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.dataService = dataService;
    }

    [Api]
    public async ValueTask<CrudListResponse> List([FromQuery] string? token)
    {
        var result = await dataService.QueryDataListAsync(token, 20).ConfigureAwait(false);

        return new CrudListResponse { Entities = result.List, NextToken = result.Token };
    }

    [Api]
    public async ValueTask<DataEntity?> Get([FromRoute] string id)
    {
        return await dataService.QueryDataAsync(id).ConfigureAwait(false);
    }

    [Api]
    public async ValueTask<CrudCreateResponse> Create([FromBody] CrudCreateRequest request)
    {
        var entity = mapper.Map<DataEntity>(request);
        entity.Id = Guid.NewGuid().ToString();
        entity.CreatedAt = DateTime.Now;

        await dataService.CreateDataAsync(entity).ConfigureAwait(false);

        logger.LogInformation("Data created. id=[{Id}]", entity.Id);

        return new CrudCreateResponse { Id = entity.Id };
    }

    [Api]
    public async ValueTask Delete([FromRoute] string id)
    {
        await dataService.DeleteDataAsync(id).ConfigureAwait(false);

        logger.LogInformation("Data deleted. id=[{Id}]", id);
    }
}
