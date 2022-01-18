namespace Template.Lambda;

using AutoMapper;

using Template.Lambda.Parameters;
using Template.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CrudCreateInput, DataEntity>();
    }
}
