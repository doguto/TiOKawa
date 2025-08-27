using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleModel
    {
        // Sceneの名前空間と名前が被っているため例外的に冗長な型記述になっている
        // TODO: 冗長でない宣言に変更
        TiOKawa.Scripts.Infra.Schema.Battle battle;
        List<BattleWave> battleWaves = new();
        
        public BattleModel(int battleId)
        {
            battle = GameDatabase.Master.BattleTable.FindById(battleId);
        }
    }
}
