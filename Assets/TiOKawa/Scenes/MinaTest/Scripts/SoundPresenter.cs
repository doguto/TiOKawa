using UniRx;
using UnityEngine;

namespace TiOKawa.Scenes.MinaTest.Scripts.Presenter {
    public class SoundPresenter : MonoBehaviour {
        [SerializeField] private Gate gate;
        [SerializeField] private SoundController soundController;

        void Start() {
            gate.OnPassed
                .Subscribe(_ => soundController.PlayGatePassSound())
                .AddTo(this);
        }
    }
}
