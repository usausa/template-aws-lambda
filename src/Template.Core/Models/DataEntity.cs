namespace Template.Models;

[DynamoDBTable("Data")]
public sealed class DataEntity
{
    // Index for listing: every item carries the same Kind, so the list is a Query on this
    // index in CreatedAt order (page by page) instead of a Scan over the whole table.
    public const string ListIndexName = "Kind-CreatedAt-index";

    public const string DefaultKind = "Data";

    [DynamoDBHashKey]
    public string Id { get; set; } = default!;

    [DynamoDBGlobalSecondaryIndexHashKey(ListIndexName)]
    public string Kind { get; set; } = DefaultKind;

    public string Name { get; set; } = default!;

    // Optimistic locking: SaveAsync succeeds only when the stored Version matches, then increments it
    [DynamoDBVersion]
    public int? Version { get; set; }

    [DynamoDBGlobalSecondaryIndexRangeKey(ListIndexName)]
    public DateTime CreatedAt { get; set; }
}
