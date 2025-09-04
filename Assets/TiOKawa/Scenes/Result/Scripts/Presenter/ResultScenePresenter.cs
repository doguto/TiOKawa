using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiOKawa.Scripts.Presenter;
using TiOKawa.Scenes.Result.Scripts.View;
using TiOKawa.Scenes.Result.Scripts.Model;


namespace TiOKawa.Scenes.Result.Scripts.Presenter
{
    public class ResultPresenter : MonoPresenter
    {
        [SerializeField] ResultSceneView resultSceneView;
        private ResultSceneModel model;

        protected override void SetupModel()
        {
            model = new ResultSceneModel();
        }
        protected override void SetupView()
        {
            resultSceneView.ShowLevel(model.GetLevel());
            resultSceneView.ShowDiedTiokawaCount(model.GetDiedTiokawaCount());
            resultSceneView.ShowDefeatedEnemyCount(model.GetDefeatedEnemyCount());
            resultSceneView.ShowTiokawaCount(model.GetTiokawaCount());
        }
    }
}

