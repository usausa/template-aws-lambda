namespace Template.Lambda.Parameters;

using System.Diagnostics.CodeAnalysis;

public class CrudCreateResponse
{
    [AllowNull]
    public string Id { get; set; }
}
