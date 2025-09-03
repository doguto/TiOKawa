using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BgmManger : MonoBehaviour
{
    [SerializeField] AudioSource bgm;

    [SerializeField] List<AudioClip> audioClips;
    // Start is called before the first frame update
    void Start()
    {
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


}
