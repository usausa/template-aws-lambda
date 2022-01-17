namespace Template.Lambda.Parameters;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class MiscValidationInput
{
    [Required]
    [AllowNull]
    public string Value { get; set; }
}
