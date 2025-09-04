using DG.Tweening;
using TiOKawa.Scripts.View;
using TMPro;
using UnityEngine;

namespace TiOKawa.Prefabs.Gate.Scripts.View
{
    public class GateView : MonoView
    {
        [SerializeField] TextMeshProUGUI text;

        Transform myTransform;

        void Awake()
        {
            myTransform = transform;
        }
        
        void Start()
        {
            MoveTo();
        }

        public void Setup(int incrementalAmount)
        {
            text.text = $"+{incrementalAmount}";
        }

        public void MoveTo()
        {
            myTransform.DOLocalMoveZ(-100, 100);
        }
    }
}
