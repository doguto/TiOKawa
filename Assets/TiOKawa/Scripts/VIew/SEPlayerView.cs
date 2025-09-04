using TiOKawa.Scripts.View;
using UnityEngine;

namespace TiOKawa.Scripts.View {
    public class SEPlayerView : MonoView
    {
        [SerializeField] private AudioClip gatePassClip;
        [SerializeField] private AudioClip collisionClip;
        [SerializeField] private AudioClip damageClip;
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip startClip;

        void Awake()
        {
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component missing on " + gameObject.name + ". SoundController will not function properly.");
            }
        }

        public void PlayGatePassSound()
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(gatePassClip);
            }
        }

        public void PlayCollisionSound()
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(collisionClip);
            }
        }

        public void PlayDamageSound()
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(damageClip);
            }
        }
        
        public void PlayStartSound() {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(startClip);
            }
        }
    }
}
