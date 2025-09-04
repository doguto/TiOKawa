using UnityEngine;
using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine.SceneManagement;
using TiOKawa.Scripts.Presenter;
using System.Collections;

namespace TiOKawa.Scenes.Title.Scripts.Presenter
{
    public class TitleScenePresenter : MonoPresenter
    {
        [SerializeField] SimpleButton startButton;
        [SerializeField] SimpleButton settingsButton;         
        [SerializeField] SEPlayerView sePlayerView; 

        protected override void SubscribeView()
        {
          //  startButton.OnClicked
            //    .Subscribe(_ => OnStartButtonClicked())
              //  .AddTo(this);

           // settingsButton.OnClicked
             //   .Subscribe(_ => OnSettingsButtonClicked())
             //   .AddTo(this);
        }

        public void OnStartButtonClicked()
        {
            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            sePlayerView.PlayStartSound();
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("StageSelect");
        }

        void OnSettingsButtonClicked()
        {
            SceneManager.LoadScene("Settings");
        }
    }
}