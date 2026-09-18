namespace Template.Mock;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

public sealed class MockTable : ITable
{
    private readonly Queue<Document> deleteDocuments = new();

    public string TableName => throw new NotSupportedException();

    public Dictionary<string, KeyDescription> Keys => throw new NotSupportedException();

    public Dictionary<string, GlobalSecondaryIndexDescription> GlobalSecondaryIndexes => throw new NotSupportedException();

    public Dictionary<string, LocalSecondaryIndexDescription> LocalSecondaryIndexes => throw new NotSupportedException();

    public List<string> LocalSecondaryIndexNames => throw new NotSupportedException();

    public List<string> GlobalSecondaryIndexNames => throw new NotSupportedException();

    public List<string> HashKeys => throw new NotSupportedException();

    public List<string> RangeKeys => throw new NotSupportedException();

    public List<AttributeDefinition> Attributes
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    // Document

    public Document FromAttributeMap(Dictionary<string, AttributeValue> data) => throw new NotSupportedException();

    public Dictionary<string, AttributeValue> ToAttributeMap(Document doc) => throw new NotSupportedException();

    public Dictionary<string, ExpectedAttributeValue> ToExpectedAttributeMap(Document doc) => throw new NotSupportedException();

    public Dictionary<string, AttributeValueUpdate> ToAttributeUpdateMap(Document doc, bool changedAttributesOnly) => throw new NotSupportedException();

    // Search

    public ISearch Scan(ScanFilter filter) => throw new NotSupportedException();

    public ISearch Scan(Expression filterExpression) => throw new NotSupportedException();

    public ISearch Scan(ScanOperationConfig config) => throw new NotSupportedException();

    public ISearch Scan(ScanDocumentOperationRequest operationRequest) => throw new NotSupportedException();

    public ISearch Query(Primitive hashKey, QueryFilter filter) => throw new NotSupportedException();

    public ISearch Query(Primitive hashKey, Expression filterExpression) => throw new NotSupportedException();

    public ISearch Query(QueryFilter filter) => throw new NotSupportedException();

    public ISearch Query(QueryOperationConfig config) => throw new NotSupportedException();

    public ISearch Query(QueryDocumentOperationRequest operationRequest) => throw new NotSupportedException();

    public ISearchVectors SearchVectors(SearchVectorsOperationRequest operationRequest) => throw new NotSupportedException();

    // Create

    public IDocumentBatchGet CreateBatchGet() => throw new NotSupportedException();

    public IDocumentBatchWrite CreateBatchWrite() => throw new NotSupportedException();

    public IDocumentTransactGet CreateTransactGet() => throw new NotSupportedException();

    public IDocumentTransactGet CreateTransactGet(ReturnConsumedCapacity returnConsumedCapacity) => throw new NotSupportedException();

    public IDocumentTransactWrite CreateTransactWrite() => throw new NotSupportedException();

    public IDocumentTransactWrite CreateTransactWrite(ReturnConsumedCapacity returnConsumedCapacity) => throw new NotSupportedException();

    // Put

    public Task<Document> PutItemAsync(Document doc, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> PutItemAsync(Document doc, PutItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> PutItemAsync(PutItemDocumentOperationRequest request, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Get

    public Task<Document> GetItemAsync(Primitive hashKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> GetItemAsync(Primitive hashKey, GetItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> GetItemAsync(Primitive hashKey, Primitive rangeKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> GetItemAsync(Primitive hashKey, Primitive rangeKey, GetItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> GetItemAsync(IDictionary<string, DynamoDBEntry> key, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> GetItemAsync(IDictionary<string, DynamoDBEntry> key, GetItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> GetItemAsync(GetItemDocumentOperationRequest request, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Update

    public Task<Document> UpdateItemAsync(Document doc, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, UpdateItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, IDictionary<string, DynamoDBEntry> key, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, IDictionary<string, DynamoDBEntry> key, UpdateItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, Primitive hashKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, Primitive hashKey, UpdateItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, Primitive hashKey, Primitive rangeKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(Document doc, Primitive hashKey, Primitive rangeKey, UpdateItemOperationConfig config, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task<Document> UpdateItemAsync(UpdateItemDocumentOperationRequest request, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Delete

    public void SetupDeleteItem(Document document) => deleteDocuments.Enqueue(document);

    public Task<Document> DeleteItemAsync(Document document, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(Document document, DeleteItemOperationConfig config, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(Primitive hashKey, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(Primitive hashKey, DeleteItemOperationConfig config, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(Primitive hashKey, Primitive rangeKey, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(Primitive hashKey, Primitive rangeKey, DeleteItemOperationConfig config, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(IDictionary<string, DynamoDBEntry> key, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(IDictionary<string, DynamoDBEntry> key, DeleteItemOperationConfig config, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());

    public Task<Document> DeleteItemAsync(DeleteItemDocumentOperationRequest request, CancellationToken cancellationToken = default) =>
        Task.FromResult(deleteDocuments.Dequeue());
}
