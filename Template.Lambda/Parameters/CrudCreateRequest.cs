namespace Template.Lambda.Parameters;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class CrudCreateRequest
{
    [Required]
    [AllowNull]
    public string Name { get; set; }
}
