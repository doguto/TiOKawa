using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable(("Battle")), MessagePackObject(true)]
    public class Battle
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int BattleStageId { get; set; }
    }
}
