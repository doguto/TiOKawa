using TiOKawa.Scripts.Infra.Schema;


namespace TiOKawa.Scripts.Infra
{
    public class TemporaryData
    {
        public BattleResult BattleResult { get; set; } = new BattleResult(1, 1, 1, 1);
        public StageChange StageChange { get; set; } = new(){BattleId = 1};
    }
}
