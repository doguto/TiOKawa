using TiOKawa.Scripts.Infra;
using UnityEditor;

namespace TiOKawa.Editor.MasterMemory
{
    public static class BinaryGeneratorTool
    {
        [MenuItem("Tools/MasterMemory/GenerateMasterBinary")]
        static void GenerateMasterBinary()
        {
            var generator = new MasterDataBinaryGenerator();
            IMasterDataFactory factory = new MasterDataFactory();
            
            var masterData = factory.Create();
            generator.Generate(masterData);
        }
    }
}
