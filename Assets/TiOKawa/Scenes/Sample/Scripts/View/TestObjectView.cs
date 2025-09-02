using TiOKawa.Scripts.View;
using TMPro;
using UnityEngine;

namespace TiOKawa.Scenes.Sample.Scripts.View
{
    public class TestObjectView : MonoView
    {
        [SerializeField] TextMeshProUGUI idText;
        [SerializeField] TextMeshProUGUI nameText;

        public override void Init()
        {
            idText.text = $"ID: 00";
            nameText.text = $"Name: Null";
        }

        public void Setup(int id, string name)
        {
            idText.text = $"ID: {id:00}";
            nameText.text = $"Name: {name}";
        }
    }
}