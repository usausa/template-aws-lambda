namespace Template.Lambda;

public sealed class HttpApiMappingProfile : Profile
{
    public HttpApiMappingProfile()
    {
        CreateMap<CrudCreateRequest, DataEntity>();
    }
}
