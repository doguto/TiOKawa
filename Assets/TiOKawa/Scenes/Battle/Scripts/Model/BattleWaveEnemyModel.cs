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

        readonly Subject<(int, GameObject)> onSpawnCalled = new();
        public IObservable<(int, GameObject)> OnSpawnCalled => onSpawnCalled;

        public int Amount => battleWaveEnemy.Amount;

        public BattleWaveEnemyModel(int battleWaveEnemyId)
        {
            battleWaveEnemy = GameDatabase.Master.BattleWaveEnemyTable.FindById(battleWaveEnemyId);
            enemyModel = new(battleWaveEnemy.EnemyId);
        }

        public void Spawn()
        {
            onSpawnCalled.OnNext((battleWaveEnemy.Id, enemyModel.Prefab));
        }
    }
}
