using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Origin;
using TiOKawa.Scripts.Infra.Schema;

namespace TiOKawa.Scripts.Infra
{
    public class MasterData
    {
        public List<Test> Tests { get; set; }
        public List<Battle> Battles { get; set; }
        public List<BattleStage> BattleStages { get; set; }
        public List<BattleWave> BattleWaves { get; set; }
        public List<BattleWaveEnemy> BattleWaveEnemies { get; set; }
        public List<BattleWaveGate> BattleWaveGates { get; set; }
        public List<Enemy> Enemies { get; set; }
    }
}
