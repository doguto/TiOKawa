using System.Collections.Generic;
using System.Linq;
using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UnityEditor;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleWaveModel
    {
        BattleWave battleWave;

        public int BattleWaveId => battleWave.Id; 
        public float Period => battleWave.Period;

        public BattleWaveModel(int battleWaveId)
        {
            battleWave = GameDatabase.Master.BattleWaveTable.FindById(battleWaveId);
        }

        public List<BattleWaveEnemyModel> GetWaveEnemyModels()
        {
            var ids = GameDatabase.Master.BattleWaveEnemyTable
                .All
                .Where(x => x.BattleWaveId == battleWave.Id)
                .Select(x => x.Id)
                .ToList();
            return ids.Select(id => new BattleWaveEnemyModel(id)).ToList();
        }

        public BattleWaveGateModel GetGateModel()
        {
            return new BattleWaveGateModel(battleWave.Id);
        }
    }
}
