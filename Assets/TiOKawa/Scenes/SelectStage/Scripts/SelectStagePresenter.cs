using TiOKawa.Scripts.Presenter;
using TiOKawa.Scenes.SelectStage.Scripts.View;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TiOKawa.Scenes.SelectStage.Scripts.Presenter
{
    public class SelectStagePresenter : MonoPresenter
    {
        [SerializeField] private SelectStageView stageView;
        [SerializeField] private string stageSceneName;

        private void Start()
        {
            stageView.OnClicked
                .Subscribe(_ => LoadStage())
                .AddTo(this);
        }

        private void LoadStage()
        {
            SceneManager.LoadScene(stageSceneName);
        }
    }

}
