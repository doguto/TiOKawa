using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.ScriptableObject
{
    [CreateAssetMenu(fileName = "BattleData", menuName = "ScriptableObject/BattleData")]
    public class BattleData : UnityEngine.ScriptableObject
    {
        public List<ScriptableBattle> battles = new();
    }

    [Serializable]
    public class ScriptableBattle
    {
        [SerializeField] int id;

        public Battle ToBattle()
        {
            return new Battle() { Id = id };
        }
    }
}
