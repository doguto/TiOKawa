using System.Collections.Generic;
using System.Linq;
using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UnityEngine;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleModel
    {
        // Sceneの名前空間と名前が被っているため例外的に冗長な型記述になっている
        // TODO: 冗長でない宣言に変更
        TiOKawa.Scripts.Infra.Schema.Battle battle;
        BattleStage battleStage;
        List<BattleWave> battleWaves;

        int battleWaveIndex;
        public bool IsLastWave { get; private set; }
        public float SpawnableStageWidth => battleStage.Width * 0.75f;
        public float SpawnPointZPosition => battleStage.SpawnPositionZ;

        public BattleModel(int battleId)
        {
            battle = GameDatabase.Master.BattleTable.FindById(battleId);
            battleStage = GameDatabase.Master.BattleStageTable.FindById(battle.BattleStageId);
            battleWaves = GameDatabase.Master.BattleWaveTable
                .All
                .Where(battleWave => battleWave.BattleId == battleId)
                .ToList();
            
            battleWaveIndex = 0;
        }

        public BattleWaveModel GetCurrentWaveModel()
        {
            var id = battleWaves[battleWaveIndex].Id;
            return new BattleWaveModel(id);
        }

        public void PrepareNextWave()
        {
            battleWaveIndex++;
            IsLastWave = battleWaveIndex >= battleWaves.Count;
        }

        public void SaveResult()
        {
            // TODO: mockなので真データを保存する
            GameDatabase.Temporary.BattleResult = new BattleResult(13, 1, 13, 3);
        }
    }
}
