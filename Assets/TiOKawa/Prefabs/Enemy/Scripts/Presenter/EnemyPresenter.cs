using System;
using TiOKawa.Prefabs.Enemy.Scripts.View;
using TiOKawa.Prefabs.Player.Scripts.Presenter;
using TiOKawa.Scripts.Presenter;
using UnityEngine;

namespace TiOKawa.Prefabs.Enemy.Scripts.Presenter
{
    public class EnemyPresenter : MonoPresenter
    {
        [SerializeField] EnemyView enemyView;

        PlayerPresenter playerPresenter;

        void Update()
        {
            if (playerPresenter.IsInPlayerCircle(enemyView.transform.position))
            {
                playerPresenter.DestroyPlayers(1);
                Destroy(this.gameObject);
            }
        }

        public void Setup(PlayerPresenter presenter)
        {
            playerPresenter = presenter;
        }
    }
}
