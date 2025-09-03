using System.Security.Cryptography.X509Certificates;
using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable("BattleStage"), MessagePackObject(true)]
    public class BattleStage
    {
        [PrimaryKey]
        public int Id { get; set; }
        [SecondaryKey(1)]
        public int BattleId { get; set; }
        public float Width { get; set; }
        public float SpawnPositionZ { get; set; }
    }
}
