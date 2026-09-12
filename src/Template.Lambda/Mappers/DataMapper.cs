namespace Template.Lambda.Mappers;

using Smart.Mapper;

internal static partial class DataMapper
{
    [Mapper]
    public static partial DataEntity ToEntity(this CrudCreateRequest request);
}
