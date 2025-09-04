using TiOKawa.Scripts.Infra.Schema;
using TiOKawa.Scripts.Repository;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TiOKawa.Scenes.Battle.Scripts.Model
{
    public class EnemyModel
    {
        readonly Enemy enemy;
        public GameObject Prefab { get; private set; }
        public int Id => enemy.Id;

        public EnemyModel(int id)
        {
            enemy = GameDatabase.Master.EnemyTable.FindById(id);
            Prefab = Addressables.LoadAssetAsync<GameObject>(enemy.Address).WaitForCompletion();
        }
    }
}
