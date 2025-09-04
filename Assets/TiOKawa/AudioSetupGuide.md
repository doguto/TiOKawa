# 音量設定連携セットアップガイド

## 完成したファイル

### 1. BgmManger.cs (更新済み)
- PlayerPrefsから音量設定を読み込み
- Master Volume × BGM Volume で最終音量を計算
- `UpdateVolumeSettings()` でリアルタイム更新

### 2. SEManager.cs (新規作成)
-効果音の音量制御クラス
- Master Volume × SFX Volume で最終音量を計算
- `PlaySE()` でクリップ番号または直接AudioClipを再生

### 3. AudioManager.cs (新規作成)
- シングルトンパターンでオーディオを一元管理
- BGMManager、SEManagerの統合制御
- `UpdateAllVolumeSettings()` で全音量を一括更新

### 4. SettingsScenePresenter.cs (更新済み)
- スライダー変更時にAudioManagerを通じて即座に音量反映

## Unity Editorでのセットアップ手順

### 1. AudioManager Prefab作成
1. 空のGameObjectを作成し「AudioManager」と命名
2. AudioManagerスクリプトをアタッチ
3. BGM Manager、SE Managerフィールドに対応するオブジェクトを設定
4. Prefab化してDontDestroyOnLoadで永続化

### 2. シーンごとの配置
各シーンで以下を配置：

#### Title Scene
- AudioManagerオブジェクト（最初のシーンのみ）
- BgmMangerオブジェクト（BGM用AudioSourceを設定）

#### Battle Scene  
- SEManagerオブジェクト（SE用AudioSourceと効果音クリップを設定）

#### Settings Scene
- 既にSettingsScenePresenterで音量変更が連携済み

### 3. 使用方法

#### BGM制御
```csharp
// BGM再生
AudioManager.Instance.PlayBGM();

// BGM切り替え
AudioManager.Instance.ChangeBGM(0);

// BGM停止
AudioManager.Instance.StopBGM();
```

#### SE制御
```csharp
// SE再生（クリップ番号指定）
AudioManager.Instance.PlaySE(0);

// SE再生（AudioClip直接指定）
AudioManager.Instance.PlaySE(clipReference);
```

## 動作の流れ

1. Settingsでスライダー操作
2. PlayerPrefsに値保存
3. AudioManager.UpdateAllVolumeSettings()実行
4. BGMManager、SEManagerの音量が即座に更新
5. 現在再生中の音声に音量変更が適用

これで設定画面の音量調整がリアルタイムでBGM・SE再生に反映されます。