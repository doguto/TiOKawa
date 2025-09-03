using MasterMemory;
using MessagePack;

namespace TiOKawa.Scripts.Infra.Schema
{
    [MemoryTable("Test"), MessagePackObject(true)]
    public class Test
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
