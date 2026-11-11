# Template project for AWS Lambda

[English](README.md) | 日本語

AWS Lambda + API Gateway のテンプレート(.NET 10)。

# ✅ 実装

| 分類 | 機能 |
| --- | --- |
| 関数 | HTTP API(API Gateway) / スケジュール / SQS / SNS / Lambda Annotations / arm64 |
| 基本 | DI(Startup) / 環境変数での設定 / CloudWatch Logs へのログ出力(独自プロバイダー) / マッパー(Smart.Mapper) |
| データ | DynamoDB CRUD / ページング(GSI への Query) / 楽観的同時実行制御(version) |
| ネットワーク | HttpClient(IHttpClientFactory) |
| デプロイ | CloudFormation(`serverless.template`) |
| テスト | 単体テスト(DynamoDB モック) |

# 🚧 未実装

| 分類 | 機能 |
| --- | --- |
| データ | RDS Proxy を使った RDB 操作 |
| 認証 | Cognito 連携による認証 |
| 分析 | Kinesis 連携によるストリーム分析 |

# 📚 ドキュメント

| ドキュメント | 内容 |
| --- | --- |
| [architecture.md](docs/architecture.md) | 設計(基本・実装機能・アーキテクチャ) |
| [deploy.md](docs/deploy.md) | ツール・ビルド・デプロイ |

# 🔗 関連プロジェクト

| プロジェクト | 説明 |
| --- | --- |
| [template-aws-api-tenant](https://github.com/usausa/template-aws-api-tenant) | AWS マルチテナントサーバーレス API のテンプレート |
| [template-aws-s3-wasm](https://github.com/usausa/template-aws-s3-wasm) | S3 + CloudFront と Cognito で動かす Blazor WebAssembly のテンプレート |
| [template-aws-line-miniapp](https://github.com/usausa/template-aws-line-miniapp) | AWS で動かす LINE ミニアプリ(LIFF)のテンプレート |
| [template-azure-functions](https://github.com/usausa/template-azure-functions) | Azure Functions(isolated worker)のテンプレート |

# 📦 自作ライブラリ

| ライブラリ | 説明 |
| --- | --- |
| [Usa.Smart.Mapper](https://github.com/usausa/Smart-Net-Mapper) | オブジェクトマッパー |
