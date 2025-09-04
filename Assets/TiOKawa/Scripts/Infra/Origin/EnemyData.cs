using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.Origin
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/Enemy")]
    public class EnemyData : ScriptableObject
    {
        public List<ScriptableEnemy> enemies = new();
    }

    [Serializable]
    public class ScriptableEnemy
    {
        [SerializeField] int id;
        [SerializeField] int hp;
        [SerializeField] float speed;
        [SerializeField] string address;

        public Enemy ToEnemy()
        {
            return new Enemy()
            {
                Id = id,
                Hp = hp,
                Speed = speed,
                Address = address
            };
        }
    }
}
