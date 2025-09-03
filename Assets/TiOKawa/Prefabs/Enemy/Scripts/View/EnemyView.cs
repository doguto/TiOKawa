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
        
        public void MoveTo(float targetZPosition)
        {
            
        }
    }
}
