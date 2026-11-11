# ビルドとデプロイ

## 🔧 ツール

デプロイ用の成果物作成及びデバッグ作業を行うため、以下のコマンドで必要なツールをインストールしておく。

```
dotnet tool update -g amazon.lambda.tools
dotnet tool update -g amazon.lambda.testtool-10.0
```

## 🚀 ビルド

リポジトリ直下で以下のコマンドを実行し、デプロイ用のzipを `Publish` に作成する。
また、CloudFormationのテンプレートとしてserverless.templateと、デプロイの既定値のaws-lambda-tools-defaults.jsonも成果物とする。

```
dotnet lambda package Publish\Template.Lambda.zip -pl src\Template.Lambda -c Release -farch arm64
copy /y src\Template.Lambda\aws-lambda-tools-defaults.json Publish\
copy /y src\Template.Lambda\serverless.template Publish\
```

## 📦 デプロイ

コマンドラインでのデプロイは以下のコマンドを成果物のあるディレクトリ(`Publish`)で実行する。

```
dotnet lambda deploy-serverless --package Template.Lambda.zip
```
