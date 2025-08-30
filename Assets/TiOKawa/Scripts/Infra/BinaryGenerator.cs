using System.IO;
using MasterMemory;
using MessagePack;
using MessagePack.Resolvers;
using UnityEditor;

namespace TiOKawa.Scripts.Infra
{
    public abstract class BinaryGenerator<T>
    {
        protected const string BinaryDirectoryPath = "Assets/TiOKawa/DataStore/Binary";
        protected abstract string DataName { get; }
        protected string BinaryFilePath => Path.Combine(BinaryDirectoryPath, $"{DataName}.bytes");
        protected string DirectoryName => Path.GetDirectoryName(BinaryFilePath);
        
        public abstract void Generate(T data);

        protected DatabaseBuilder CreateMessagePack()
        {
            var messagePackResolver = CompositeResolver.Create(
                MasterMemoryResolver.Instance,
                StandardResolver.Instance
            );
            var options = MessagePackSerializerOptions.Standard.WithResolver(messagePackResolver);
            MessagePackSerializer.DefaultOptions = options;
            
            return new DatabaseBuilder();
        }

        protected void WriteBinary(DatabaseBuilder builder)
        {
            var binaryData = builder.Build();
            if (!Directory.Exists(DirectoryName)) Directory.CreateDirectory(DirectoryName);
            
            File.WriteAllBytes(BinaryFilePath, binaryData);
            AssetDatabase.Refresh();
        }
    }
}
