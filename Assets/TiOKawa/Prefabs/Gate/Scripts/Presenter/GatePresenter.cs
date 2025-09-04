using TiOKawa.Prefabs.Gate.Scripts.View;
using TiOKawa.Scripts.Presenter;
using UnityEngine;

namespace TiOKawa.Prefabs.Gate.Scripts.Presenter
{
    public class GatePresenter : MonoPresenter
    {
        [SerializeField] GateView gateView;

        public void Setup(int incrementalAmount)
        {
            gateView.Setup(incrementalAmount);
        }
    }
}
