using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BgmManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] List<AudioClip> audioClips;
    
    private float masterVolume = 1.0f;
    private float bgmVolume = 1.0f;

    void Start()
    {
        LoadVolumeSettings();
        ApplyVolumeSettings();
        StartBgm();
    }
    //bgmを鳴らす処理 最初流す
    public void StartBgm()
    {
        bgm.Play();

        
    }

    // Update is called once per frame
    //bgmを止める処理関数
    public void StopBgm()
    {
        bgm.Stop();
    }

    //音楽を切り替える関数
    public void ChangeBgm(int bgmNumber)
    {
        bgm.clip = audioClips[bgmNumber];
        bgm.Play();
    }

    void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 1.0f);
    }

    void ApplyVolumeSettings()
    {
        bgm.volume = masterVolume * bgmVolume;
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
