using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.Origin
{
    [CreateAssetMenu(fileName = "BattleData", menuName = "ScriptableObject/BattleData")]
    public class BattleData : ScriptableObject
    {
        public List<ScriptableBattle> battles = new();
    }

    [Serializable]
    public class ScriptableBattle
    {
        [SerializeField] int id;
        [SerializeField] int battleStageId;

        public Battle ToBattle()
        {
            return new Battle()
            {
                Id = id,
                BattleStageId = battleStageId,
            };
        }
    }
}
