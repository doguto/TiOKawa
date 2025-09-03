using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class EnemyModel
    {
        readonly Enemy enemy;

        public EnemyModel(int id)
        {
            enemy = GameDatabase.Master.EnemyTable.FindById(id);
        }

        public GameObject LoadPrefab()
        {
            var prefab = Addressables.LoadAssetAsync<GameObject>(enemy.Address).WaitForCompletion();
            return prefab;
        }
    }
}
