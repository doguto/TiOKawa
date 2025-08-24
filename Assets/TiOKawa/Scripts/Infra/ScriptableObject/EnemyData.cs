using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.ScriptableObject
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/Enemy")]
    public class EnemyData : UnityEngine.ScriptableObject
    {
        public List<ScriptableEnemy> enemies = new();
    }

    [Serializable]
    public class ScriptableEnemy
    {
        [SerializeField] int id;
        [SerializeField] int hp;

        public Enemy ToEnemy()
        {
            return new Enemy(){Id = id, Hp = hp};
        }
    }
}
