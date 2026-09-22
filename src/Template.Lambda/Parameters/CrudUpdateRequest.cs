namespace Template.Lambda.Parameters;

public sealed class CrudUpdateRequest
{
    [Required]
    public string Name { get; set; } = default!;

    // The Version returned by Get / List. The update is rejected (412) when the item has changed since
    public int Version { get; set; }
}
