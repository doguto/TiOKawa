using System;
using DG.Tweening;
using TiOKawa.Scripts.View;
using TMPro;
using UniRx;
using UnityEngine;

namespace TiOKawa.Prefabs.Gate.Scripts.View
{
    public class GateView : MonoView
    {
        [SerializeField] TextMeshProUGUI text;
        
        Transform myTransform;
        public ReactiveProperty<Vector3> Position { get; } = new();

        void Awake()
        {
            myTransform = transform;
            Position.Value = myTransform.position;
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
            myTransform.DOLocalMoveZ(-150, 20);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
