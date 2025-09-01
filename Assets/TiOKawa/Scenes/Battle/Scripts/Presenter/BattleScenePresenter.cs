using System;
using System.Collections.Generic;
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
        BattleWaveModel currentWaveModel;
        List<BattleWaveEnemyModel> currentWaveEnemyModels;

        protected override void SetupModel()
        {
            // TODO: battleIDの取得処理
            // 仮に battleId = 1
            battleModel = new BattleModel(1);
            currentWaveModel = battleModel.GetCurrentWaveModel();
            currentWaveEnemyModels = currentWaveModel.GetWaveEnemyModels();
        }

        void UpdateWave()
        {
            currentWaveModel = battleModel.GetNextWaveModel();
            currentWaveEnemyModels = currentWaveModel.GetWaveEnemyModels();
            
            Observable.Timer(TimeSpan.FromSeconds(currentWaveModel.Period))
                .Subscribe(_ => UpdateWave())
                .AddTo(this);
            
            foreach (var waveEnemyModel in currentWaveEnemyModels)
            {
                Observable.Timer(TimeSpan.FromSeconds(currentWaveModel.Period / waveEnemyModel.Amount));
            }
        }

        void SpawnEnemyEachTime()
        {
            
        }
    }
}
