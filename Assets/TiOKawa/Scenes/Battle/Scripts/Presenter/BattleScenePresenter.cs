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

        protected override void AfterInit()
        {
            UpdateWave();
            Debug.Log("Setting Subscriber");
        }

        void UpdateWave()
        {
            if (battleModel.IsLastWave)
            {
                Debug.Log("Finished This Battle!!!!!", this);
                return;
            }

            currentWaveModel = battleModel.GetCurrentWaveModel();
            currentWaveEnemyModels = currentWaveModel.GetWaveEnemyModels();

            battleModel.PrepareNextWave();

            Observable.Timer(TimeSpan.FromSeconds(currentWaveModel.Period))
                .Subscribe(_ => UpdateWave())
                .AddTo(this);

            foreach (var waveEnemyModel in currentWaveEnemyModels)
            {
                waveEnemyModel.OnSpawnCalled.Subscribe(SpawnEnemy);

                //  Waveが切り替わった後にスポーンしないように、waveEnemyModel.Amount + 1
                Observable.Interval(TimeSpan.FromSeconds(currentWaveModel.Period / (waveEnemyModel.Amount + 1)))
                    .Take(waveEnemyModel.Amount)
                    .Subscribe(_ => waveEnemyModel.Spawn())
                    .AddTo(this);
            }
        }

        void SpawnEnemy(int id)
        {
            Debug.Log($"EnemySpawn: {id}");
        }
    }
}
