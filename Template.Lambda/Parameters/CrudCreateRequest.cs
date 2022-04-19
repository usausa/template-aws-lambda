namespace Template.Lambda.Parameters;

public class CrudCreateRequest
{
    [Required]
    public string Name { get; set; } = default!;
}
