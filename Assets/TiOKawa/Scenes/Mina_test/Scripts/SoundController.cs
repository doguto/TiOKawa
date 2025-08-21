using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip gatePassClip;
    public AudioClip collisionClip;
    public AudioClip damageClip;
    AudioSource audioSource;

    void Start() {
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
