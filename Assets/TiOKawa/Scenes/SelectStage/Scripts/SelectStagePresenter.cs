using TiOKawa.Scripts.Presenter;
using TiOKawa.Scenes.SelectStage.Scripts.View;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace TiOKawa.Scenes.SelectStage.Scripts.Presenter
{
    public class SelectStagePresenter : MonoPresenter
    {
        [SerializeField] private SelectStageView stageView;
        const string stageSceneName = "Battle"; 
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
