using TiOKawa.Scripts.Presenter;
using TiOKawa.Scenes.SelectStage.Scripts.View;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace TiOKawa.Scenes.SelectStage.Scripts.Presenter
{
    public class SelectStagePresenter : MonoPresenter
    {
        [SerializeField] private SelectStageView stageView;
        const string stageSceneName = "Battle";

        private Dictionary<int, int> stageMapping = new Dictionary<int, int>()
        {
            { 0, 1 },
            { 1, 1 },
            { 2, 1 },
            { 3, 1 },
        };
        private void Start()
        {
            stageView.OnClicked
                .Subscribe(buttonId =>
                {
                    if (stageMapping.TryGetValue(buttonId, out int stageChangeId))
                    {
                        LoadStage(stageChangeId);
                    }
                    else
                    {
                        Debug.LogError($"ButtonId {buttonId} に対応する StageChangeId が見つかりません");
                    }
                })
                .AddTo(this);
        }

        private void LoadStage(int StageChangeId)
        {
            PlayerPrefs.SetInt("SelectedBattleId", StageChangeId);
            PlayerPrefs.Save();
            SceneManager.LoadScene(stageSceneName);
        }
    }

}
