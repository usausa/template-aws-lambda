namespace Template.Lambda.Parameters;

using System.Diagnostics.CodeAnalysis;

using Template.Models;

public class CrudListOutput
{
    [AllowNull]
    public List<DataEntity> Entities { get; set; }

    public string? NextToken { get; set; }
}
