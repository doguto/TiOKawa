using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.Origin
{
    [CreateAssetMenu(fileName = "BattleWaveEnemyData", menuName = "ScriptableObject/BattleWaveEnemy")]
    public class BattleWaveEnemyData : ScriptableObject
    {
        public List<ScriptableBattleWaveEnemy> battleWaveEnemies = new();
    }

    [Serializable]
    public class ScriptableBattleWaveEnemy
    {
        [SerializeField] int id;
        [SerializeField] int battleWaveId;
        [SerializeField] int enemyId;
        [SerializeField] int amount;

        public BattleWaveEnemy ToBattleWaveEnemy()
        {
            return new BattleWaveEnemy()
            {
                Id = id,
                BattleWaveId = battleWaveId,
                EnemyId = enemyId,
                Amount = amount
            };
        }
    }
}
