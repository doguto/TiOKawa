using UnityEngine;

namespace TiOKawa.Scenes.MinaTest.Scripts.View {
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip gatePassClip;
        [SerializeField] private AudioClip collisionClip;
        [SerializeField] private AudioClip damageClip;
        private AudioSource audioSource;

        void Awake() {
            if (audioSource == null) {
                Debug.LogError("AudioSource component missing on " + gameObject.name + ". SoundController will not function properly.");
            }
        }

        public void PlayGatePassSound() {
            if (audioSource != null) {
                audioSource.PlayOneShot(gatePassClip);
            }
        }

        public void PlayCollisionSound() {
            if (audioSource != null) {
                audioSource.PlayOneShot(collisionClip);
            }
        }

        public void PlayDamageSound() {
            if (audioSource != null) {
                audioSource.PlayOneShot(damageClip);
            }
        }
    }
}
