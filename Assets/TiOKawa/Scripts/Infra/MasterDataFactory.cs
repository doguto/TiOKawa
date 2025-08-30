using System.Linq;
using TiOKawa.Scripts.Infra.Origin;
using UnityEditor;

namespace TiOKawa.Scripts.Infra
{
    public class MasterDataFactory : MasterDataFactoryBase
    {
        public override MasterData Create()
        {
            var masterData = new MasterData();

            var testData = AssetDatabase.LoadAssetAtPath<TestData>($"{OriginDataDirectory}/TestData.asset");
            masterData.Tests = testData.tests.Select(x => x.ToTest()).ToList();

            var battleData = AssetDatabase.LoadAssetAtPath<BattleData>($"{OriginDataDirectory}/BattleData.asset");
            masterData.Battles = battleData.battles.Select(x => x.ToBattle()).ToList();
            
            var battleWaveData = AssetDatabase.LoadAssetAtPath<BattleWaveData>($"{OriginDataDirectory}/BattleWaveData.asset");
            masterData.BattleWaves = battleWaveData.battleWaves.Select(x => x.ToBattleWave()).ToList();

            var enemyData = AssetDatabase.LoadAssetAtPath<EnemyData>($"{OriginDataDirectory}/EnemyData.asset");
            masterData.Enemies = enemyData.enemies.Select(x => x.ToEnemy()).ToList();
            
            return masterData;
        }
    }
}
