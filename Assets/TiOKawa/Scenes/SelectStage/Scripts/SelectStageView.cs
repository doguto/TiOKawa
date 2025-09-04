using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

namespace TiOKawa.Scenes.SelectStage.Scripts.View
{
    public class SelectStageView : MonoView, IPointerClickHandler
    {
        protected readonly Subject<Unit> onClicked = new();

        public IObservable<Unit> OnClicked => onClicked;
        public bool IsActive { get; private set; } = true;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsActive) return;
            
            onClicked.OnNext(Unit.Default);
        }

        void OnDestroy()
        {
            onClicked.Dispose();
        }
    }

}
