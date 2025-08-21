using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip gatePassClip;
    [SerializeField] private AudioClip collisionClip;
    [SerializeField] private AudioClip damageClip;
    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGatePassSound() {
        audioSource.PlayOneShot(gatePassClip);
    }

    public void PlayCollisionSound() {
        audioSource.PlayOneShot(collisionClip);
    }

    public void PlayDamageSound() {
        audioSource.PlayOneShot(damageClip);
    }

}
