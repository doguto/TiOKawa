using DG.Tweening;
using TiOKawa.Scripts.View;
using UnityEngine;

namespace TiOKawa.Prefabs.Enemy.Scripts.View
{
    public class EnemyView : MonoView
    {
        Transform myTransform;

        void Awake()
        {
            myTransform = transform;
        }

        void Start()
        {
            MoveTo(-100, 60);
        }

        public void MoveTo(float moveValue, float time)
        {
            myTransform.DOLocalMoveZ(moveValue, time);
        }
    }
}
