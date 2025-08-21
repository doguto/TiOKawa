# TiOKawa コーディングルール

## MVPアーキテクチャについて

TiOKawaは、**MVP（Model-View-Presenter）**アーキテクチャパターンを採用しています。このパターンは、関心の分離を通じてコードの保守性と拡張性を向上させることを目的としています。

### MVPの基本概念

- **Model**: ビジネスロジックとデータの管理を担当する層
- **View**: ユーザーインターフェースと入力の処理を担当する層  
- **Presenter**: ModelとViewの仲介役として、データの流れとロジックを管理する層

このアーキテクチャにより、各層が独立性を保ちながら、UniRxを活用したリアクティブプログラミングによって効率的な通信を実現しています。

## 各レイヤーの実装ルール

### Model層

Model層は純粋なビジネスロジックとデータ管理を担当します。

#### 必須ルール

- **MonoBehaviour継承禁止**: Modelクラスは`MonoBehaviour`を継承してはいけません
- データの保持とビジネスロジックの実装に専念する
- Unityの機能に直接依存しない設計にする
- 必要に応じてUniRxの`ReactiveProperty`やObservableパターンを活用する

#### 実装例

```csharp
namespace TiOKawa.Scripts.Model
{
    public class PlayerModel 
    {
        public ReactiveProperty<int> Health { get; } = new ReactiveProperty<int>(100);
        public ReactiveProperty<string> Name { get; } = new ReactiveProperty<string>("");
        
        public void TakeDamage(int damage)
        {
            Health.Value = Mathf.Max(0, Health.Value - damage);
        }
    }
}
```

### Presenter層

Presenter層は、ModelとViewを接続し、アプリケーションのフローを制御します。

#### 必須ルール

- **MonoPresenter継承必須**: 本来MonoBehaviour継承は禁止だが、TiOKawaでは`MonoPresenter`を継承する
- **基本的にScene一つにつき一つ**: 各シーンには原則として一つのPresenterを配置する
- **Scene内のViewをSerializeFieldで保持**: 管理するViewコンポーネントは`SerializeField`で参照を保持する
- **SetupModel()でModelを作成**: 使用するModelインスタンスは`SetupModel()`メソッド内で初期化する
- **オブザーバーパターンでViewを監視**: ViewからのイベントをUniRxで監視し、適切に処理する

#### 実装例

```csharp
namespace TiOKawa.Scripts.Presenter
{
    public class GamePresenter : MonoPresenter
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private UIView uiView;
        
        private PlayerModel playerModel;
        
        protected override void SetupModel()
        {
            playerModel = new PlayerModel();
        }
        
        protected override void SetupView()
        {
            // View の初期化処理
            playerView.Init();
            uiView.Init();
        }
        
        protected override void SubscribeView()
        {
            // View からのイベントを監視
            playerView.OnHealthChanged
                .Subscribe(health => uiView.UpdateHealthDisplay(health))
                .AddTo(gameObject);
        }
    }
}
```

### View層

View層は、ユーザーインターフェースと入力処理を担当します。

#### 必須ルール

- **MonoView継承必須**: すべてのViewクラスは`MonoView`を継承する
- **Awake(), Start(), Update()は基本使わない**: ライフサイクルメソッドの直接使用は避ける
- **IObservable, Subjectを活用**: オブザーバーパターンの起点として`IObservable`と`Subject`を使用する
- イベントの発信源となり、ユーザーの操作をPresenterに伝達する
- UI要素の状態更新はPresenterからの指示で行う

#### 実装例

```csharp
namespace TiOKawa.Scripts.View
{
    public class PlayerView : MonoView
    {
        [SerializeField] private Button attackButton;
        [SerializeField] private Slider healthSlider;
        
        private readonly Subject<Unit> onAttackClicked = new Subject<Unit>();
        private readonly Subject<int> onHealthChanged = new Subject<int>();
        
        public IObservable<Unit> OnAttackClicked => onAttackClicked;
        public IObservable<int> OnHealthChanged => onHealthChanged;
        
        public override void Init()
        {
            // ボタンのクリックイベントを監視
            attackButton.OnClickAsObservable()
                .Subscribe(_ => onAttackClicked.OnNext(Unit.Default))
                .AddTo(gameObject);
        }
        
        public void UpdateHealth(int health)
        {
            healthSlider.value = health;
            onHealthChanged.OnNext(health);
        }
        
        private void OnDestroy()
        {
            onAttackClicked.Dispose();
            onHealthChanged.Dispose();
        }
    }
}
```

## 追加のガイドライン

### UniRxの活用

- イベントの購読には`AddTo(gameObject)`を使用してライフサイクル管理を行う
- `ReactiveProperty`を使用してデータの変更を監視可能にする
- `Subject`を使用してカスタムイベントを実装する

### 命名規則

- Model: `〇〇Model`（例: `PlayerModel`, `GameStateModel`）
- View: `〇〇View`（例: `PlayerView`, `MenuView`）  
- Presenter: `〇〇Presenter`（例: `GamePresenter`, `TitlePresenter`）

### フォルダ構成

```
Assets/TiOKawa/Scenes/[SceneName]/Scripts/
├── Model/           # Modelクラス
├── Presenter/       # Presenterクラス
└── View/           # Viewクラス
```

各シーンごとに独立したMVPフォルダ構成を作成し、アセンブリ参照で適切に分離することを推奨します。