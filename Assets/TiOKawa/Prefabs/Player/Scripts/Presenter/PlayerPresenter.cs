using System;
using TiOKawa.Prefabs.Player.Scripts.Model;
using TiOKawa.Prefabs.Player.Scripts.View;
using TiOKawa.Scripts.Presenter;
using UnityEngine;

namespace TiOKawa.Prefabs.Player.Scripts.Presenter
{
    public class PlayerPresenter : MonoPresenter
    {
        [SerializeField] PlayerMinionView playerMinionView;
        
        readonly PlayerModel playerModel = new();

        public float GateCollisionRadius => playerMinionView.CurrentMaxRadius * 0.9f;
        
        public void SpawnPlayer() => playerMinionView.SpawnPlayer();
        public void SpawnPlayers(int count) => playerMinionView.SpawnPlayers(count);

        public void SetPosition(float x)
        {
            playerMinionView.MoveTo(new Vector3(x, playerModel.YPosition, playerModel.ZPosition));
        }

        public bool IsInPlayerCircle(Vector3 position)
        {
            var vector2Position = new Vector2(position.x, position.z + 60);
            var length = vector2Position.x * vector2Position.x + vector2Position.y * vector2Position.y;
            return length < (GateCollisionRadius + 3) * (GateCollisionRadius + 3);
        }
    }
}
