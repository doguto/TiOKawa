using UnityEngine;

namespace TiOKawa.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private BgmManager bgmManager;
    [SerializeField] private SEManager seManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (bgmManager == null)
            bgmManager = FindObjectOfType<BgmManager>();
        
        if (seManager == null)
            seManager = FindObjectOfType<SEManager>();
    }

    public void UpdateAllVolumeSettings()
    {
        if (bgmManager)
            bgmManager.UpdateVolumeSettings();
        
        if (seManager)
            seManager.UpdateVolumeSettings();
    }

    public void PlayBGM()
    {
        if (bgmManager)
            bgmManager.StartBgm();
    }

    public void StopBGM()
    {
        if (bgmManager)
            bgmManager.StopBgm();
    }

    public void ChangeBGM(int bgmNumber)
    {
        if (bgmManager)
            bgmManager.ChangeBgm(bgmNumber);
    }

    public void PlaySE(int seNumber)
    {
        if (seManager)
            seManager.PlaySE(seNumber);
    }

    public void PlaySE(AudioClip clip)
    {
        if (seManager)
            seManager.PlaySE(clip);
    }
    }
}