using System;
using System.Collections.Generic;
using TiOKawa.Prefabs.Player.Scripts.Presenter;
using TiOKawa.Scenes.Battle.Scripts.Model;
using TiOKawa.Scripts.Presenter;
using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TiOKawa.Scenes.Battle.Scripts.Presenter
{
    public class BattleScenePresenter : MonoPresenter
    {
        [SerializeField] PlayerPresenter playerPresenter;
        [SerializeField] DraggableArea playerControlArea;

        BattleModel battleModel;
        BattleWaveModel currentWaveModel;
        List<BattleWaveEnemyModel> currentWaveEnemyModels;
        BattleWaveGateModel currentBattleWaveGateModel;

        protected override void SetupModel()
        {
            // TODO: battleIDの取得処理
            // 仮に battleId = 1
            battleModel = new BattleModel(1);
            currentWaveModel = battleModel.GetCurrentWaveModel();
            currentWaveEnemyModels = currentWaveModel.GetWaveEnemyModels();
        }

        protected override void SubscribeView()
        {
            playerControlArea.OnDragged.Subscribe(UpdatePlayerPosition);
        }

        protected override void AfterInit()
        {
            playerPresenter.SpawnPlayer();

            UpdateWave();
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
            currentBattleWaveGateModel = currentWaveModel.GetGateModel();

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

            if (!currentBattleWaveGateModel.HasGate) return;

            // TODO: SpawnTypeをカラムに追加次第、引数に設定
            var spawnPositionX = GetSpawnPositionX(SpawnType.RightRandom, battleModel.SpawnableStageWidth);
            Instantiate(
                currentBattleWaveGateModel.Prefab,
                new Vector3(spawnPositionX, 2.5f, battleModel.SpawnPointZPosition),
                Quaternion.identity
            );
        }

        void SpawnEnemy((SpawnType spawnType, GameObject prefab)obj)
        {
            var stageWidth = battleModel.SpawnableStageWidth;
            var spawnPositionX = GetSpawnPositionX(obj.spawnType, stageWidth);

            Instantiate(
                obj.prefab,
                new Vector3(spawnPositionX, 1.1f, battleModel.SpawnPointZPosition),
                new Quaternion(0, 1, 0, 0)
            );
        }

        void UpdatePlayerPosition(Vector2 position)
        {
            // 二次元を三次元に変換するときに指の動きとずれるので、係数で調整している
            // TODO: FIXME
            var coef = 8f;
            var worldX = (position.x - playerControlArea.CenterXPosition) * coef / playerControlArea.HalfSize;
            playerPresenter.SetPosition(worldX);
        }

        float GetSpawnPositionX(SpawnType spawnType, float stageWidth)
        {
            return spawnType switch
            {
                SpawnType.AllRandom => Random.Range(-stageWidth, stageWidth),
                SpawnType.LeftRandom => Random.Range(-stageWidth, 0),
                SpawnType.RightRandom => Random.Range(0, stageWidth),
                SpawnType.Left => -stageWidth,
                SpawnType.Right => stageWidth,
                SpawnType.Center => 0,
                _ => Random.Range(-stageWidth, stageWidth)
            };
        }
    }
}
