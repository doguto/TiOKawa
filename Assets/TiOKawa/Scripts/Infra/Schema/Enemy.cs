using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable("Enemy"), MessagePackObject(true)]
    public class Enemy
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Hp { get; set; }
        public string Address { get; set; }
    }
}
