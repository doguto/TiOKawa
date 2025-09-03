namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public enum SpawnType
    {
        AllRandom = 0,
        LeftRandom = 1,
        RightRandom = 2,
        Left = 3,
        Right = 4,
        Center = 5,
    }

    public static class SpawnTypeExtensions
    {
        public static SpawnType ToSpawnType(this int spawnTypeId)
        {
            return (SpawnType)spawnTypeId;
        }

        public static int ToInt(this SpawnType spawnType)
        {
            return (int)spawnType;
        }

        public static SpawnType ToSpawnType(this string spawnTypeName)
        {
            return spawnTypeName switch
            {
                "AllRandom" => SpawnType.AllRandom,
                "LeftRandom" => SpawnType.LeftRandom,
                "RightRandom" => SpawnType.RightRandom,
                "Left" => SpawnType.Left,
                "Right" => SpawnType.Right,
                "Center" => SpawnType.Center,
                _ => SpawnType.AllRandom
            };
        }
    }
}
