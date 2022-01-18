namespace Template.Models;

using System.Diagnostics.CodeAnalysis;

using Amazon.DynamoDBv2.DataModel;

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
