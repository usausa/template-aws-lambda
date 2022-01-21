namespace Template.Lambda;

using AutoMapper;

using Template.Lambda.Parameters;
using Template.Models;

public sealed class HttpApiMappingProfile : Profile
{
    public HttpApiMappingProfile()
    {
        CreateMap<CrudCreateInput, DataEntity>();
    }
}
