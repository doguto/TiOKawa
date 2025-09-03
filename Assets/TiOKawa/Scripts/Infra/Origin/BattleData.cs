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
        [SerializeField] int spawnPointZPosition = 130;

        public Battle ToBattle()
        {
            return new Battle()
            {
                Id = id,
                SpawnPointZPosition = spawnPointZPosition
            };
        }
    }
}
