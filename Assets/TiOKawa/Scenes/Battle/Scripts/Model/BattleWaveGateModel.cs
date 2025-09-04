using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class BattleWaveGateModel
    {
        readonly BattleWaveGate battleWaveGate;

        public int IncrementalAmount => battleWaveGate.IncrementalAmount;
        public GameObject Prefab { get; }
        public bool HasGate { get; private set; }

        public BattleWaveGateModel(int battleWaveId)
        {
            HasGate = GameDatabase.Master.BattleWaveGateTable.TryFindByBattleWaveId(battleWaveId, out battleWaveGate);
            if (!HasGate) return;

            Prefab = Addressables.LoadAssetAsync<GameObject>("Assets/TiOKawa/Prefabs/Gate/Gate.prefab")
                .WaitForCompletion();
        }
    }
}
