namespace Template.Lambda.Parameters;

public sealed class CrudListResponse
{
    public List<DataEntity> Entities { get; set; } = default!;

    public string? NextToken { get; set; }
}
