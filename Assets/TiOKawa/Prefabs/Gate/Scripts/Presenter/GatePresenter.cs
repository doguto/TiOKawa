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
            var x = gateView.transform.position.x;
            var z = gateView.transform.position.z;
            if (!playerPresenter.IsInPlayerCircle(x - 2.5f, x + 2.5f, z)) return;

            playerPresenter.SpawnPlayers(incrementalAmount);
            Destroy(gameObject);
        }

        public void Setup(int incrementalAmount, PlayerPresenter playerPresenter)
        {
            gateView.Setup(incrementalAmount);
            this.playerPresenter = playerPresenter;
            this.incrementalAmount = incrementalAmount;
        }
    }
}
