namespace Template.Lambda.Parameters;

public class CrudListResponse
{
    public List<DataEntity> Entities { get; set; } = default!;

    public string? NextToken { get; set; }
}
