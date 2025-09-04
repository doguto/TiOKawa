using System;
using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UniRx;
using UnityEngine;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleWaveEnemyModel
    {
        BattleWaveEnemy battleWaveEnemy;

        EnemyModel enemyModel;

        readonly Subject<(SpawnType, int)> onSpawnCalled = new();
        public IObservable<(SpawnType, int)> OnSpawnCalled => onSpawnCalled;

        public int Amount => battleWaveEnemy.Amount;
        public SpawnType SpawnType => battleWaveEnemy.SpawnTypeName.ToSpawnType();

        public BattleWaveEnemyModel(int battleWaveEnemyId)
        {
            battleWaveEnemy = GameDatabase.Master.BattleWaveEnemyTable.FindById(battleWaveEnemyId);
            enemyModel = new(battleWaveEnemy.EnemyId);
        }

        public void Spawn()
        {
            onSpawnCalled.OnNext((SpawnType, enemyModel.Id));
        }
    }
}
