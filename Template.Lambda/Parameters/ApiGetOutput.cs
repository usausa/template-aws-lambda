namespace Template.Lambda.Parameters;

using System.Diagnostics.CodeAnalysis;

public class ApiGetOutput
{
    [AllowNull]
    public string[] Values { get; set; }
}
