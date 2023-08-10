namespace Template.Mock;

using Amazon.DynamoDBv2.DocumentModel;

public class MockDynamoDBContext : IDynamoDBContext
{
    private readonly Queue<object> loadObjects = new();

    public void Dispose()
    {
    }

    // Document

    public Document ToDocument<T>(T value) => throw new NotSupportedException();

    public Document ToDocument<T>(T value, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public T FromDocument<T>(Document document) => throw new NotSupportedException();

    public T FromDocument<T>(Document document, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents) => throw new NotSupportedException();

    public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    // Create

    public BatchGet<T> CreateBatchGet<T>(DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public MultiTableBatchGet CreateMultiTableBatchGet(params BatchGet[] batches) => throw new NotSupportedException();

    public BatchWrite<T> CreateBatchWrite<T>(DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public MultiTableBatchWrite CreateMultiTableBatchWrite(params BatchWrite[] batches) => throw new NotSupportedException();

    public TransactGet<T> CreateTransactGet<T>(DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public MultiTableTransactGet CreateMultiTableTransactGet(params TransactGet[] transactionParts) => throw new NotSupportedException();

    public TransactWrite<T> CreateTransactWrite<T>(DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public MultiTableTransactWrite CreateMultiTableTransactWrite(params TransactWrite[] transactionParts) => throw new NotSupportedException();

    // Save

    public Task SaveAsync<T>(T value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task SaveAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Load

    public void SetupLoad<T>(T value) => loadObjects.Enqueue(value!);

    public Task<T> LoadAsync<T>(object hashKey, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(T keyObject, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(T keyObject, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    // Delete

    public Task DeleteAsync<T>(T value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // ExecuteBatch

    public Task ExecuteBatchGetAsync(BatchGet[] batches, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task ExecuteBatchWriteAsync(BatchWrite[] batches, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task ExecuteTransactGetAsync(TransactGet[] transactionParts, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task ExecuteTransactWriteAsync(TransactWrite[] transactionParts, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Search

    public AsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public AsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    public AsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();

    // Table

    public Table GetTargetTable<T>(DynamoDBOperationConfig? operationConfig = null) => throw new NotSupportedException();
}
