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
            databaseBuilder.Append(data.Battles);
            databaseBuilder.Append(data.BattleWaves);
            databaseBuilder.Append(data.BattleWaveEnemies);
            databaseBuilder.Append(data.Enemies);
            
            WriteBinary(databaseBuilder);
        }
    }
}
