namespace TiOKawa.Scripts.Infra
{
    public abstract class MasterDataFactoryBase
    {
        protected const string OriginDataDirectory = "Assets/TiOKawa/DataStore/Origin";

        public abstract MasterData Create();
    }
}
