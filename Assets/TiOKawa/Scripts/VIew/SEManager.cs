using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] List<AudioClip> seClips;
    
    private float masterVolume = 1.0f;
    private float sfxVolume = 1.0f;

    void Start()
    {
        LoadVolumeSettings();
        ApplyVolumeSettings();
    }

    public void PlaySE(int seNumber)
    {
        if (seNumber < 0 || seNumber >= seClips.Count)
        {
            Debug.LogWarning($"SE番号 {seNumber} は範囲外です");
            return;
        }

        seAudioSource.PlayOneShot(seClips[seNumber]);
    }

    public void PlaySE(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("SEクリップがnullです");
            return;
        }

        seAudioSource.PlayOneShot(clip);
    }

    void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1.0f);
    }

    void ApplyVolumeSettings()
    {
        seAudioSource.volume = masterVolume * sfxVolume;
    }

    public void UpdateVolumeSettings()
    {
        LoadVolumeSettings();
        ApplyVolumeSettings();
    }

    void OnEnable()
    {
        UpdateVolumeSettings();
    }
}