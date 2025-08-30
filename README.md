# TiOKawa

## 概要

TiOKawaは、MVP（Model-View-Presenter）アーキテクチャパターンを使用してUnity開発に構造化されたアプローチを提供するUnityフレームワークです。このフレームワークは、関心の分離を行い、UniRx統合を通じてリアクティブプログラミング機能を提供することで、開発者が保守性と拡張性の高いUnityプロジェクトを作成できるように設計されています。

主な特徴：
- Unity向けMVPアーキテクチャパターンの実装
- 迅速なプロジェクトセットアップのためのシーンスキャフォールディングツール
- UniRx統合によるリアクティブUIコンポーネント
- 明確な関心の分離を持つモジュラーアセンブリ構造
- 自動プロジェクト構造生成のためのUnity Editorツール

## アーキテクチャ

TiOKawaは以下の構造でMVP（Model-View-Presenter）パターンを実装しています：

### コアコンポーネント

- **Model**: ビジネスロジックと状態管理を扱うデータ層
- **View**: ユーザーインタラクションを処理するMonoBehaviourベースのコンポーネントを含むUI層
- **Presenter**: ModelとViewを接続し、データとユーザーインタラクションの流れを管理する仲介層

### 主要クラス

- `MonoView`: すべてのViewコンポーネントの抽象基底クラス。初期化ライフサイクルを提供
- `MonoPresenter`: Model、View、サブスクリプションのセットアップフックを持つPresenterコンポーネントの抽象基底クラス
- `ButtonBase`: イベント処理にUniRxを使用するリアクティブボタンの実装
- `SceneScaffold`: MVPフォルダ構造とアセンブリ参照の自動生成を行うUnity Editorツール

### プロジェクト構造

```
Assets/TiOKawa/
├── Editor/
│   └── SceneScaffold.cs        # スキャフォールディング用Editorツール
├── Scripts/
│   ├── Model/                  # ビジネスロジック層
│   ├── Presenter/              # 仲介層
│   │   └── MonoPresenter.cs
│   └── VIew/                   # UI層
│       ├── MonoView.cs
│       ├── ButtonBase.cs
│       └── SimpleButton.cs
└── Scenes/                     # シーン固有の実装
    ├── Battle/
    └── Title/
```

### 依存関係

- **UniRx**: リアクティブプログラミングとイベント処理のため
- **UniTask**: UnityでのAsync/Awaitサポートのため

## 貢献者

- **kuto** - プロジェクト作成者およびメイン開発者
- **copilot-swe-agent[bot]** - 自動化による貢献
