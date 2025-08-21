using UnityEngine;
using UniRx;

// 例）ゲートを通った判定
public class Gate : MonoBehaviour {
    private readonly subject<Unit> onPassed = new();
    public IObservable<Unit> OnPassed => onPassed;

    // private void OnTriggerEnter(Collider other) {
    //     if () {
    //         onPassed.OnNext(Unit.Default);

    //     }
    // }

    void OnDestroy() {
    onPassed.Dispose();
    }
}