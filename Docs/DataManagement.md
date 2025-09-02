# DataManagement
データの管理方法について

## MasterData


## UserData
ユーザーデータは基本的にJsonでローカルに保存することとする。
理由は以下の通り
* クラウド環境への保存は金銭的コストがかかる
* 実装が比較的楽
* テキストファイルから視覚的に内容が把握できる
### Load
ログイン時に一括でユーザーデータをロードする。
```mermaid
sequenceDiagram
    actor User
    participant GameManager
    participant BinaryGenerator
    participant UserDataRepository
    participant JsonUtility
    participant Json
    participant DatabaseBuilder
    
    User->>+GameManager: Login
    GameManager->>+BinaryGenerator: GenerateBinary()
    BinaryGenerator->>JsonUtility: Load
    JsonUtility->>Json: Read
    Json-->>JsonUtility: Data
    JsonUtility-->>BinaryGenerator: return UserData
    BinaryGenerator->>DatabaseBuilder: Append(UserData.AsSchema()) & Build()
    DatabaseBuilder-->>BinaryGenerator: return Binary
    BinaryGenerator-->>-GameManager: Finish
    GameManager->>+UserDataRepository: Load()
    UserDataRepository->>MemoryDatabase: new(binary)
    MemoryDatabase-->>UserDataRepository: Instance
    UserDataRepository-->>-GameManager: Finish
    GameManager-->>-User: Finish Load
```

### Save
ユーザーデータの更新が入るたびにセーブする
```mermaid
sequenceDiagram
    actor User
    participant UserDataRepository
    participant JsonUtility
    participant UserData.json
    
    User->>+UserDataRepository: Save()
    UserDataRepository->>JsonUtility: ToJson(UserData.AsMiddleSchema())
    JsonUtility-->>UserDataRepository: return Json
    UserDataRepository->>UserData.json: Write
    UserDataRepository-->>-User: Finish
```