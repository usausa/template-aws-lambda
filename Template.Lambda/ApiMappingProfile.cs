namespace Template.Lambda;

public sealed class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<CrudCreateRequest, DataEntity>();
    }
}
