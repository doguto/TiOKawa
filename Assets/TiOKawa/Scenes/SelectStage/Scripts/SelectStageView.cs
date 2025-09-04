using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

namespace TiOKawa.Scenes.SelectStage.Scripts.View
{
    public class SelectStageView : MonoView, IPointerClickHandler
    {
        [SerializeField] private int buttonId;
        protected readonly Subject<int> onClicked = new();

        public IObservable<int> OnClicked => onClicked;
        public bool IsActive { get; private set; } = true;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsActive) return; 

            onClicked.OnNext(buttonId);
        }

        void OnDestroy()
        {
            onClicked.Dispose();
        }
    }

}
