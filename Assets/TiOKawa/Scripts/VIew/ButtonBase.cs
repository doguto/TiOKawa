using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TiOKawa.Scripts.View
{
    [DisallowMultipleComponent]
    public abstract class ButtonBase : MonoView, IPointerClickHandler
    {
        protected readonly Subject<Unit> onClicked = new();
        
        public IObservable<Unit> OnClicked => onClicked;
        public bool IsActive { get; private set; } = true;

        protected virtual void OnClick(){}
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsActive) return;
            
            OnClick();
            onClicked.OnNext(Unit.Default);
        }

        void OnDestroy()
        {
            onClicked.Dispose();
        }
    }
}
