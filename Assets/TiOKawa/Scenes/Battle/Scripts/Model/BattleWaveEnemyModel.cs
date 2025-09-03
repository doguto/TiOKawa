using System;
using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UniRx;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleWaveEnemyModel
    {
        BattleWaveEnemy battleWaveEnemy;
        
        
        readonly Subject<int> onSpawnCalled = new();
        public IObservable<int> OnSpawnCalled => onSpawnCalled;
        
        public int Amount => battleWaveEnemy.Amount;
        
        public BattleWaveEnemyModel(int battleWaveEnemyId)
        {
            battleWaveEnemy = GameDatabase.Master.BattleWaveEnemyTable.FindById(battleWaveEnemyId);
        }

        public void Spawn()
        {
            onSpawnCalled.OnNext(battleWaveEnemy.Id);
        }
    }
}
