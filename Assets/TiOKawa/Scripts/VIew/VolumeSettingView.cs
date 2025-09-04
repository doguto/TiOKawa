using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TiOKawa.Scripts.View;

namespace TiOKawa.Scripts.View
{
    public class VolumeSettingView : MonoView
    {
        [SerializeField] Slider masterVolumeSlider;
        [SerializeField] Slider sfxVolumeSlider;
        [SerializeField] Slider bgmVolumeSlider;

        readonly Subject<float> onMasterVolumeChanged = new();
        readonly Subject<float> onSfxVolumeChanged = new();
        readonly Subject<float> onBgmVolumeChanged = new();

        public IObservable<float> OnMasterVolumeChanged => onMasterVolumeChanged;
        public IObservable<float> OnSfxVolumeChanged => onSfxVolumeChanged;
        public IObservable<float> OnBgmVolumeChanged => onBgmVolumeChanged;

        public override void Init()
        {
            masterVolumeSlider.onValueChanged.AsObservable()
                .Subscribe(value => onMasterVolumeChanged.OnNext(value))
                .AddTo(this);

            sfxVolumeSlider.onValueChanged.AsObservable()
                .Subscribe(value => onSfxVolumeChanged.OnNext(value))
                .AddTo(this);

            bgmVolumeSlider.onValueChanged.AsObservable()
                .Subscribe(value => onBgmVolumeChanged.OnNext(value))
                .AddTo(this);
        }

        public void SetVolumes(float masterVolume, float sfxVolume, float bgmVolume)
        {
            masterVolumeSlider.value = masterVolume;
            sfxVolumeSlider.value = sfxVolume;
            bgmVolumeSlider.value = bgmVolume;
        }

        void OnDestroy()
        {
            onMasterVolumeChanged?.Dispose();
            onSfxVolumeChanged?.Dispose();
            onBgmVolumeChanged?.Dispose();
        }
    }
}