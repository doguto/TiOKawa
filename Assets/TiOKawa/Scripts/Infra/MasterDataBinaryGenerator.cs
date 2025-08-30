namespace TiOKawa.Scripts.Infra
{
    public class MasterDataBinaryGenerator : BinaryGenerator<MasterData>
    {
        protected override string DataName => "MasterData";
        public override void Generate(MasterData data)
        {
            var databaseBuilder = CreateMessagePack();
            
            // MasterDataの追加に伴い、ここにAppendしていく
            databaseBuilder.Append(data.Tests);
            
            WriteBinary(databaseBuilder);
        }
    }
}
