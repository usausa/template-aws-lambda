namespace Template.Lambda.Parameters;

using System.Diagnostics.CodeAnalysis;

public class ApiGetInput
{
    public string? Name { get; set; }
}

public class ApiGetOutput
{
    [AllowNull]
    public string[] Values { get; set; }
}
