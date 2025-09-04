using TiOKawa.Prefabs.Player.Scripts.Model;
using TiOKawa.Prefabs.Player.Scripts.View;
using TiOKawa.Scripts.Presenter;
using UnityEngine;

namespace TiOKawa.Prefabs.Player.Scripts.Presenter
{
    public class PlayerPresenter : MonoPresenter
    {
        [SerializeField] PlayerMinionView playerMinionView;
        
        PlayerModel playerModel = new();

        public void SetPosition(float x)
        {
            playerMinionView.MoveTo(new Vector3(x, playerModel.YPosition, playerModel.ZPosition));
        }
    }
}
