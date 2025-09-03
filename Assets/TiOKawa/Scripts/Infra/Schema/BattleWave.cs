using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable("BattleWave"), MessagePackObject(true)]
    public class BattleWave
    {
        [PrimaryKey]
        public int Id { get; set; }
        [SecondaryKey(1)]
        public int BattleId { get; set; }
        public float Period { get; set; }
    }
}
