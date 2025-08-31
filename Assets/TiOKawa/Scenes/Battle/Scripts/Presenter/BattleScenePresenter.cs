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
        [SerializeField] SimpleButton button;
        
        BattleModel battleModel;

        protected override void Init()
        {
        }

        protected override void SubscribeView()
        {
            button.OnClicked.Subscribe(Hoge);
        }
        
        void Hoge(Unit _){}
    }
}
