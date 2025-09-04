namespace TiOKawa.Scripts.Infra.Schema
{
    public class BattleResult
    {
        public int DiedTiokawaCount { get; } = 1;
        public int Level { get; } = 1;
        public int DefeatedEnemyCount { get; } = 1;
        public int TiokawaCount { get; } = 1;

        public BattleResult(int diedTiokawaCount, int level, int defeatedEnemyCount, int tiokawaCount)
        {
            DiedTiokawaCount = diedTiokawaCount;
            Level = level;
            DefeatedEnemyCount = defeatedEnemyCount;
            TiokawaCount = tiokawaCount;
        }
    }
}
