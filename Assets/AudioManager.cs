using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private BgmManger bgmManager;
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
            bgmManager = FindObjectOfType<BgmManger>();
        
        if (seManager == null)
            seManager = FindObjectOfType<SEManager>();
    }

    public void UpdateAllVolumeSettings()
    {
        if (bgmManager != null)
            bgmManager.UpdateVolumeSettings();
        
        if (seManager != null)
            seManager.UpdateVolumeSettings();
    }

    public void PlayBGM()
    {
        if (bgmManager != null)
            bgmManager.StartBgm();
    }

    public void StopBGM()
    {
        if (bgmManager != null)
            bgmManager.StopBgm();
    }

    public void ChangeBGM(int bgmNumber)
    {
        if (bgmManager != null)
            bgmManager.ChangeBgm(bgmNumber);
    }

    public void PlaySE(int seNumber)
    {
        if (seManager != null)
            seManager.PlaySE(seNumber);
    }

    public void PlaySE(AudioClip clip)
    {
        if (seManager != null)
            seManager.PlaySE(clip);
    }
}