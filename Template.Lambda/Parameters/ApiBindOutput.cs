namespace Template.Lambda.Parameters;

using System.Diagnostics.CodeAnalysis;

public class ApiBindOutput
{
    [AllowNull]
    public string[] Values { get; set; }
}
