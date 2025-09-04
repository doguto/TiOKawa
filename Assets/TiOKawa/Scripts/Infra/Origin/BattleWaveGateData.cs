using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.Origin
{
    [CreateAssetMenu(fileName = "BattleWaveGateData", menuName = "ScriptableObject/BattleWaveGateData")]
    public class BattleWaveGateData : ScriptableObject
    {
        public List<ScriptableBattleWaveGate> battleWaveGates = new();
    }

    [Serializable]
    public class ScriptableBattleWaveGate
    {
        [SerializeField] int id;
        [SerializeField] int battleWaveId;
        [SerializeField] int incrementalAmount;

        public BattleWaveGate ToBattleWaveGateData()
        {
            return new BattleWaveGate()
            {
                Id = id,
                BattleWaveId = battleWaveId,
                IncrementalAmount = incrementalAmount
            };
        }
    }
}
