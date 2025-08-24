namespace TiOKawa.Scripts.Infra
{
    public class MasterDataFactory : IMasterDataFactory
    {
        public MasterData Create()
        {
            var masterData = new MasterData();
            return masterData;
        }
    }
}
