using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable("BattleWaveEnemy"), MessagePackObject(true)]
    public class BattleWaveEnemy
    {
        [PrimaryKey]
        public int Id { get; set; }
        [SecondaryKey(1)]
        public int BattleWaveId { get; set; }
        [SecondaryKey(2)]
        public int EnemyId { get; set; }
        public int Amount { get; set; }
        public string SpawnTypeName { get; set; }
    }
}
