using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.ScriptableObject
{
    [CreateAssetMenu(fileName = "BattleWaveData", menuName = "ScriptableObject/BattleWave")]
    public class BattleWaveData : UnityEngine.ScriptableObject
    {
        public List<ScriptableBattleWave> battleWaves = new();
    }

    [Serializable]
    public class ScriptableBattleWave
    {
        [SerializeField] int id;
        [SerializeField] int battleId;
        [SerializeField] float period;
        [SerializeField] int spawnPerSecond;

        public BattleWave ToBattleWave()
        {
            return new BattleWave()
            {
                Id = id,
                BattleId = battleId,
                Period = period,
                SpawnPerSecond = spawnPerSecond
            };
        }
    }
}
