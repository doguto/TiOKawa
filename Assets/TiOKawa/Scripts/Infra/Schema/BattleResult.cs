namespace TiOKawa.Scripts.Infra.Schema
{
    public class BattleResult
    {
        public int DiedTiokawaCount { get; }
        public int Level { get; }
        public int DefeatedEnemyCount { get; }
        public int TiokawaCount { get; }

        public BattleResult(int diedTiokawaCount, int level, int defeatedEnemyCount, int tiokawaCount)
        {
            DiedTiokawaCount = diedTiokawaCount;
            Level = level;
            DefeatedEnemyCount = defeatedEnemyCount;
            TiokawaCount = tiokawaCount;
        }
    }
}
