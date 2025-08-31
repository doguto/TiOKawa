using System;
using TiOKawa.Scenes.Battle.Scripts.Model;
using TiOKawa.Scripts.Presenter;
using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine;

namespace TiOKawa.Scenes.Battle.Scripts.Presenter
{
    public class BattleScenePresenter : MonoPresenter
    {
        BattleModel battleModel;

        protected override void Init()
        {
        }

        protected override void SetupModel()
        {
            // TODO: battleIDの取得処理
            // 仮に battleId = 1
            battleModel = new BattleModel(1);
        }
    }
}
