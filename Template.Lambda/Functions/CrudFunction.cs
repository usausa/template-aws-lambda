namespace Template.Lambda.Functions;

using Amazon.Lambda.APIGatewayEvents;

using AutoMapper;

using Template.Lambda.Helpers;
using Template.Lambda.Parameters;
using Template.Models;
using Template.Services;

using Microsoft.Extensions.Logging;

public class CrudFunction
{
    private readonly ILogger<CrudFunction> logger;

    private readonly IMapper mapper;

    private readonly DataService dataService;

    public CrudFunction()
        : this(ServiceLocator.GetService<ILogger<CrudFunction>>(), ServiceLocator.GetService<IMapper>(), ServiceLocator.GetService<DataService>())
    {
    }

    public CrudFunction(ILogger<CrudFunction> logger, IMapper mapper, DataService dataService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.dataService = dataService;
    }

    // TODO list

    public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request)
    {
        if (!BindHelper.TryBind(request.PathParameters, "id", out string id))
        {
            return Results.BadRequest();
        }

        var entity = await dataService.QueryDataAsync(id).ConfigureAwait(false);
        if (entity is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(entity);
    }

    public async Task<APIGatewayProxyResponse> Create(APIGatewayProxyRequest request)
    {
        if (!request.TryBind<CrudCreateInput>(out var input) ||
            !ValidationHelper.Validate(input))
        {
            return Results.BadRequest();
        }

        var entity = mapper.Map<DataEntity>(input);
        entity.Id = Guid.NewGuid().ToString();
        entity.CreatedAt = DateTime.Now;
        await dataService.CreateDataAsync(entity).ConfigureAwait(false);

        logger.LogInformation("Data created. id=[{Id}]", entity.Id);

        return Results.Ok(new CrudCreateOutput { Id = entity.Id });
    }

    public async Task<APIGatewayProxyResponse> Delete(APIGatewayProxyRequest request)
    {
        if (!BindHelper.TryBind(request.PathParameters, "id", out string id))
        {
            return Results.BadRequest();
        }

        await dataService.DeleteDataAsync(id).ConfigureAwait(false);

        logger.LogInformation("Data deleted. id=[{Id}]", id);

        return Results.Ok();
    }
}
