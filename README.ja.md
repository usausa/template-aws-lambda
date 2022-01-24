# Template for AWS Lambda application

## 言語

- [English](./README.md)
- [Japanese](./README.ja.md)

## 基本方針

* AWS Lambda及びAPI Gatewayを使用したサーバレスプロジェクト構成の雛形を提携する
* コスト効率の良いarm64での実装を基本とする
* アプリケーション全体は.NET Coreで構成するが、補助的なLambdaについてはNode.jsを用いることもある
* ステージング環境、プロダクション環境等の環境に応じた設定が必要な場合は環境変数で指定する形とする
* Lambdaのボイラーテンプレート部分はSource Generatorsを使用して自動生成する
* アプリケーションのデプロイにはCloudFormationを使用する

## ビルド方法

以下のコマンドによりデプロイ用のzipを作成する。
また、CloudFormationのテンプレートとしてserverless.templateも成果物とする。

```
dotnet lambda package Template.Lambda.zip -pl Template.Lambda -c Release -farch arm64
copy /y Template.Lambda\serverless.template Publish\
```

## デプロイ方法

コマンドラインでのデプロイは以下のコマンドを成果物のあるディレクトリで実行する。

```
dotnet lambda deploy-serverless --package Template.Lambda.zip
```

## 実装サンプル

本テンプレートでは以下の機能を実装している。



(TODO)

## アーキテクチャ解説



(TODO)

## 次に行う事

* RDS Proxyを使用したRDB操作
* Cognito連携による認証処理
* Kinesis連携によるIoT分析
