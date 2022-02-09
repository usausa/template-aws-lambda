namespace Template.Lambda.Parameters;

public class CrudListResponse
{
    [AllowNull]
    public List<DataEntity> Entities { get; set; }

    public string? NextToken { get; set; }
}
