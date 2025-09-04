using System;
using TiOKawa.Prefabs.Gate.Scripts.View;
using TiOKawa.Prefabs.Player.Scripts.Presenter;
using TiOKawa.Scripts.Presenter;
using UniRx;
using UnityEngine;

namespace TiOKawa.Prefabs.Gate.Scripts.Presenter
{
    public class GatePresenter : MonoPresenter
    {
        [SerializeField] GateView gateView;
        PlayerPresenter playerPresenter;
        int incrementalAmount;

        public void SetActive(bool active) => gateView.SetActive(active);

        void Update()
        {
            if (playerPresenter.IsInPlayerCircle(gateView.transform.position))
            {
                playerPresenter.SpawnPlayers(incrementalAmount);
                Destroy(this);
            }
        }

        public void Setup(int incrementalAmount, PlayerPresenter playerPresenter)
        {
            gateView.Setup(incrementalAmount);
            this.playerPresenter = playerPresenter;
            this.incrementalAmount = incrementalAmount;
        }
    }
}
