using UniRx;
using UnityEngine;

public class SoundPresenter : MonoBehaviour {
    [SerializeField] private Gate gate;
    [SerializeField] private SoundController soundController;

    void Start() {
        gate.OnPassed
            .Subscribe(_ => soundController.PlayGatePassSound())
            .AddTo(this);.
    }

}