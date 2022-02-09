namespace Template.Models;

[DynamoDBTable("Data")]
public class DataEntity
{
    [DynamoDBHashKey]
    [AllowNull]
    public string Id { get; set; }

    [AllowNull]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }
}
