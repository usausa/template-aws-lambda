namespace Template.Mock;

using Amazon.DynamoDBv2.DocumentModel;

public sealed class MockDynamoDBContext : IDynamoDBContext
{
    private readonly Queue<object> loadObjects = new();

    public void Dispose()
    {
    }

    public void RegisterTableDefinition(Table table) => throw new NotSupportedException();

    // Document

    public Document ToDocument<T>(T value) => throw new NotSupportedException();

    public Document ToDocument<T>(T value, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public Document ToDocument<T>(T value, ToDocumentConfig toDocumentConfig) => throw new NotSupportedException();

    public T FromDocument<T>(Document document) => throw new NotSupportedException();

    public T FromDocument<T>(Document document, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public T FromDocument<T>(Document document, FromDocumentConfig fromDocumentConfig) => throw new NotSupportedException();

    public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents) => throw new NotSupportedException();

    public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IEnumerable<T> FromDocuments<T>(IEnumerable<Document> documents, FromDocumentConfig fromDocumentConfig) => throw new NotSupportedException();

    // Create

    public IBatchGet<T> CreateBatchGet<T>() => throw new NotSupportedException();

    public IBatchGet<T> CreateBatchGet<T>(DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IBatchGet<T> CreateBatchGet<T>(BatchGetConfig batchGetConfig) => throw new NotSupportedException();

    public IMultiTableBatchGet CreateMultiTableBatchGet(params IBatchGet[] batches) => throw new NotSupportedException();

    public IBatchWrite<T> CreateBatchWrite<T>() => throw new NotSupportedException();

    public IBatchWrite<T> CreateBatchWrite<T>(DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IBatchWrite<object> CreateBatchWrite(Type valuesType) => throw new NotSupportedException();

    public IBatchWrite<object> CreateBatchWrite(Type valuesType, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IBatchWrite<T> CreateBatchWrite<T>(BatchWriteConfig batchWriteConfig) => throw new NotSupportedException();

    public IBatchWrite<object> CreateBatchWrite(Type valuesType, BatchWriteConfig batchWriteConfig) => throw new NotSupportedException();

    public IMultiTableBatchWrite CreateMultiTableBatchWrite(params IBatchWrite[] batches) => throw new NotSupportedException();

    public ITransactGet<T> CreateTransactGet<T>() => throw new NotSupportedException();

    public ITransactGet<T> CreateTransactGet<T>(DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public ITransactGet<T> CreateTransactGet<T>(TransactGetConfig transactGetConfig) => throw new NotSupportedException();

    public IMultiTableTransactGet CreateMultiTableTransactGet(params ITransactGet[] transactionParts) => throw new NotSupportedException();

    public ITransactWrite<T> CreateTransactWrite<T>() => throw new NotSupportedException();

    public ITransactWrite<T> CreateTransactWrite<T>(DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public ITransactWrite<T> CreateTransactWrite<T>(TransactWriteConfig transactWriteConfig) => throw new NotSupportedException();

    public IMultiTableTransactWrite CreateMultiTableTransactWrite(params ITransactWrite[] transactionParts) => throw new NotSupportedException();

    // Save

    public Task SaveAsync<T>(T value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task SaveAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task SaveAsync<T>(T value, SaveConfig saveConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task SaveAsync(Type valueType, object value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task SaveAsync(Type valueType, object value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task SaveAsync(Type valueType, object value, SaveConfig saveConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Load

    public void SetupLoad<T>(T value) => loadObjects.Enqueue(value!);

    public Task<T> LoadAsync<T>(object hashKey, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, LoadConfig loadConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(object hashKey, object rangeKey, LoadConfig loadConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(T keyObject, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(T keyObject, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    public Task<T> LoadAsync<T>(T keyObject, LoadConfig loadConfig, CancellationToken cancellationToken = default) =>
        Task.FromResult((T)loadObjects.Dequeue());

    // Delete

    public Task DeleteAsync<T>(T value, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(T value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(T value, DeleteConfig deleteConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, DeleteConfig deleteConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task DeleteAsync<T>(object hashKey, object rangeKey, DeleteConfig deleteConfig, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // ExecuteBatch

    public Task ExecuteBatchGetAsync(params IBatchGet[] batches) => throw new NotSupportedException();

    public Task ExecuteBatchGetAsync(IBatchGet[] batches, CancellationToken cancellationToken) => throw new NotSupportedException();

    public Task ExecuteBatchWriteAsync(IBatchWrite[] batches, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // ExecuteTransact

    public Task ExecuteTransactGetAsync(ITransactGet[] transactionParts, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public Task ExecuteTransactWriteAsync(ITransactWrite[] transactionParts, CancellationToken cancellationToken = default) => throw new NotSupportedException();

    // Search

    public IAsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions) => throw new NotSupportedException();

    public IAsyncSearch<T> ScanAsync<T>(ContextExpression filterExpression) => throw new NotSupportedException();

    public IAsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, ScanConfig scanConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> ScanAsync<T>(ContextExpression filterExpression, ScanConfig scanConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> FromScanAsync<T>(ScanOperationConfig scanConfig, FromScanConfig fromScanConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> QueryAsync<T>(object hashKeyValue) => throw new NotSupportedException();

    public IAsyncSearch<T> QueryAsync<T>(object hashKeyValue, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryConfig queryConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values) => throw new NotSupportedException();

    public IAsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values, QueryConfig queryConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public IAsyncSearch<T> FromQueryAsync<T>(QueryOperationConfig queryConfig, FromQueryConfig fromQueryConfig) => throw new NotSupportedException();

    // Table

    public ITable GetTargetTable<T>() => throw new NotSupportedException();

    public ITable GetTargetTable<T>(DynamoDBOperationConfig operationConfig) => throw new NotSupportedException();

    public ITable GetTargetTable<T>(GetTargetTableConfig getTargetTableConfig) => throw new NotSupportedException();
}
