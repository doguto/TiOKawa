using System.Collections.Generic;
using TiOKawa.Scripts.View;
using UnityEngine;

namespace TiOKawa.Prefabs.Player.Scripts.View
{
    public class PlayerMinionView : MonoView
    {
        Transform myTransform;
        List<PlayerView> players = new();

        void Awake()
        {
            myTransform = transform;
        }
        
        public void MoveTo(Vector3 targetPosition)
        {
            myTransform.position = targetPosition;
        }
    }
}
