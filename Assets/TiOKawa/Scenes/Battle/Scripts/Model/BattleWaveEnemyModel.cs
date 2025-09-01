using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleWaveEnemyModel
    {
        BattleWaveEnemy battleWaveEnemy;
        
        public int Amount => battleWaveEnemy.Amount;
        
        public BattleWaveEnemyModel(int battleWaveEnemyId)
        {
            battleWaveEnemy = GameDatabase.Master.BattleWaveEnemyTable.FindById(battleWaveEnemyId);
        }
    }
}
