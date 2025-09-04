using TiOKawa.Scripts.View;
using TMPro;
using UnityEngine;

namespace TiOKawa.Prefabs.Gate.Scripts.View
{
    public class GateView : MonoView
    {
        [SerializeField] TextMeshProUGUI text;

        public void Setup(int incrementalAmount)
        {
            text.text = $"+{incrementalAmount}";
        }
    }
}
