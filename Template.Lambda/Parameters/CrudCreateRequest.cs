namespace Template.Lambda.Parameters;

public sealed class CrudCreateRequest
{
    [Required]
    public string Name { get; set; } = default!;
}
