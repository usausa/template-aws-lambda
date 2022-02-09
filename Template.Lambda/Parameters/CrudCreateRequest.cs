namespace Template.Lambda.Parameters;

public class CrudCreateRequest
{
    [Required]
    [AllowNull]
    public string Name { get; set; }
}
