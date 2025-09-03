using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.Origin
{
    [CreateAssetMenu(fileName = "BattleStageData", menuName = "ScriptableObject/BattleStageData")]
    public class BattleStageData : ScriptableObject
    {
        public List<ScriptableBattleStage> battleStages = new();
    }

    [Serializable]
    public class ScriptableBattleStage
    {
        [SerializeField] int id;
        [SerializeField] float width;
        [SerializeField] float spawnPositionZ;

        public BattleStage ToBattleStage()
        {
            return new BattleStage()
            {
                Id = id,
                Width = width,
                SpawnPositionZ = spawnPositionZ
            };
        }
    }
}
