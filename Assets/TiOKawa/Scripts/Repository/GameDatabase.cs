using MasterMemory;
using MessagePack;
using MessagePack.Resolvers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TiOKawa.Scripts.Repository
{
    public static class GameDatabase
    {
        const string BinaryDirectoryPath = "Assets/TiOKawa/DataStore/Binary";

        const string MasterDataBinaryName = "MasterData.bytes";

        public static MemoryDatabase Master { get; private set; }

        public static TemporaryData Temporary { get; private set; }

        static GameDatabase()
        {
            var masterDataBinaryPath = $"{BinaryDirectoryPath}/{MasterDataBinaryName}";

            // MessagePackの初期化
            var messagePackResolvers = CompositeResolver.Create(
                MasterMemoryResolver.Instance,
                StandardResolver.Instance
            );
            var options = MessagePackSerializerOptions.Standard.WithResolver(messagePackResolvers);
            MessagePackSerializer.DefaultOptions = options;

            Master = CreateDatabase(masterDataBinaryPath);
        }
        
        static MemoryDatabase CreateDatabase(string binaryPath)
        {
            var binaryAsset = Addressables.LoadAssetAsync<TextAsset>(binaryPath).WaitForCompletion();
            var binary = binaryAsset.bytes;
            return new MemoryDatabase(binary);
        }
    }
}
