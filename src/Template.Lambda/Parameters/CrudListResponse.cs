namespace Template.Lambda.Parameters;

#pragma warning disable CA1002
#pragma warning disable CA2227
public sealed class CrudListResponse
{
    public List<DataEntity> Entities { get; set; } = default!;

    public string? NextToken { get; set; }
}
#pragma warning restore CA2227
#pragma warning restore CA1002
