# Template project for AWS Lambda

[Template](https://usausa.github.io/template/) project for AWS Lambda.

# ✅ Implement

| Category | Feature |
| --- | --- |
| Function | HTTP API (API Gateway) / Schedule / SQS / SNS / Lambda Annotations (source generator) / arm64 |
| Basic | DI (Startup) / Settings from environment variables / Logging to CloudWatch Logs (custom provider) / Mapper (Smart.Mapper) |
| Data | DynamoDB CRUD / Paging (GSI query) / Optimistic concurrency (version) |
| Network | HttpClient (IHttpClientFactory) |
| Deploy | CloudFormation (`serverless.template`) |
| Test | Unit tests (DynamoDB mock) |

# 🚧 Pending

| Category | Feature |
| --- | --- |
| Data | RDB with RDS Proxy |
| Auth | Authentication with Cognito |
| Analytics | Stream analysis with Kinesis |

# 📚 Docs

The documents in `docs` are in Japanese.

| Document | Contents |
| --- | --- |
| [architecture.md](docs/architecture.md) | Design (basics, features, layers) |
| [deploy.md](docs/deploy.md) | Tools, build, and deploy |

# 🔗 Related Projects

| Project | Description |
| --- | --- |
| [template-aws-api-tenant](https://github.com/usausa/template-aws-api-tenant) | Multi-tenant serverless API template on AWS |
| [template-aws-s3-wasm](https://github.com/usausa/template-aws-s3-wasm) | Blazor WebAssembly template on S3 + CloudFront with Cognito |
| [template-aws-line-miniapp](https://github.com/usausa/template-aws-line-miniapp) | LINE Mini App (LIFF) template on AWS |
| [template-azure-functions](https://github.com/usausa/template-azure-functions) | Azure Functions (isolated worker) template |

# 📦 My Libraries

| Library | Description |
| --- | --- |
| [Usa.Smart.Mapper](https://github.com/usausa/Smart-Net-Mapper) | Object mapper |
