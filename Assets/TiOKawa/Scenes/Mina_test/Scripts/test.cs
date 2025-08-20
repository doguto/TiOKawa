using UnityEngine;

public class TestController : MonoBehaviour
{
    SoundController soundController;

    void Start() {
        soundController = FindObjectOfType<SoundController>();
    }

    void Update() {
    // 効果音を鳴らす条件
    if (Input.GetKeyDown(KeyCode.RightArrow)) {
        soundController.PlayCollisionSound();     
        }
    }
}