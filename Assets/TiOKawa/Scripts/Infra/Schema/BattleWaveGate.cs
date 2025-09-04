using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable("BattleWaveGate"), MessagePackObject(true)]
    public class BattleWaveGate
    {
        [PrimaryKey]
        public int Id { get; set; }
        [SecondaryKey(1)]
        public int BattleWaveId { get; set; }
        public int IncrementalAmount { get; set; }
    }
}
