using UnityEngine;
using TiOKawa.Scripts.View;
using TiOKawa.Scenes.Settings.Scripts.View;
using UniRx;
using UnityEngine.SceneManagement;
using TiOKawa.Scripts.Presenter;

namespace TiOKawa.Scenes.Settings.Scripts.Presenter
{
    public class SettingsScenePresenter : MonoPresenter
    {
        [SerializeField] VolumeSettingView volumeSettingView;
        [SerializeField] SimpleButton backButton;

        protected override void SubscribeView()
        {
            backButton.OnClicked
                .Subscribe(_ => OnBackButtonClicked())
                .AddTo(this);

            volumeSettingView.OnMasterVolumeChanged
                .Subscribe(volume => OnMasterVolumeChanged(volume))
                .AddTo(this);

            volumeSettingView.OnSfxVolumeChanged
                .Subscribe(volume => OnSfxVolumeChanged(volume))
                .AddTo(this);

            volumeSettingView.OnBgmVolumeChanged
                .Subscribe(volume => OnBgmVolumeChanged(volume))
                .AddTo(this);
        }

        protected override void SetupView()
        {
            volumeSettingView.Init();
            LoadSettings();
        }

        void OnBackButtonClicked()
        {
            SceneManager.LoadScene("Title");
        }

        void OnMasterVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("MasterVolume", volume);
            PlayerPrefs.Save();
            
            if (AudioManager.Instance != null)
                AudioManager.Instance.UpdateAllVolumeSettings();
        }

        void OnSfxVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("SfxVolume", volume);
            PlayerPrefs.Save();
            
            if (AudioManager.Instance != null)
                AudioManager.Instance.UpdateAllVolumeSettings();
        }

        void OnBgmVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("BgmVolume", volume);
            PlayerPrefs.Save();
            
            if (AudioManager.Instance != null)
                AudioManager.Instance.UpdateAllVolumeSettings();
        }

        void LoadSettings()
        {
            var masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
            var sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1.0f);
            var bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 1.0f);

            volumeSettingView.SetVolumes(masterVolume, sfxVolume, bgmVolume);
        }
    }
}