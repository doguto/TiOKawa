using System.Linq;
using TiOKawa.Scripts.Infra.ScriptableObject;
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
            
            return masterData;
        }
    }
}
