using UnityEngine;
using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine.SceneManagement;
using TiOKawa.Scripts.Presenter;
namespace TiOKawa.Scenes.Title.Scripts.Presenter
{
    public class TitleScenePresenter : MonoPresenter
    {
        [SerializeField] SimpleButton startButton;
        [SerializeField] SimpleButton settingsButton;

        protected override void SubscribeView()
        {
            startButton.OnClicked
                .Subscribe(_ => OnStartButtonClicked())
                .AddTo(this);

            settingsButton.OnClicked
                .Subscribe(_ => OnSettingsButtonClicked())
                .AddTo(this);
        }

        void OnStartButtonClicked()
        {
            SceneManager.LoadScene("Battle");
        }

        void OnSettingsButtonClicked()
        {
            SceneManager.LoadScene("Settings");
        }
    }
}