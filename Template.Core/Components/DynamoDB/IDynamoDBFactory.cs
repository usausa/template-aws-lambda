namespace Template.Components.DynamoDB;

using Amazon.DynamoDBv2.DataModel;

public interface IDynamoDBFactory
{
    IDynamoDBContext Create();
}
