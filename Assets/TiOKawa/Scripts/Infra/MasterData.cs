using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;

namespace TiOKawa.Scripts.Infra
{
    public class MasterData
    {
        public List<Test> Tests { get; set; }
        public List<Battle> Battles { get; set; }
        public List<BattleWave> BattleWaves { get; set; }
    }
}
