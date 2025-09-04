using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TiOKawa.Scripts.View
{
    [DisallowMultipleComponent]
    public class DraggableArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        readonly Subject<Vector2> onDragged = new();
        readonly Subject<Vector2> onDragStart = new();
        readonly Subject<Vector2> onDragEnd = new();

        public IObservable<Vector2> OnDragged => onDragged;
        public IObservable<Vector2> OnDragStart => onDragStart;
        public IObservable<Vector2> OnDragEnd => onDragEnd;
        
        public bool IsActive { get; private set; } = true;

        public void SetActive(bool active)
        {
            IsActive = active;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsActive) return;

            onDragStart.OnNext(eventData.position);
            onDragged.OnNext(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!IsActive) return;

            onDragEnd.OnNext(eventData.position);
            onDragged.OnNext(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!IsActive) return;

            onDragged.OnNext(eventData.position);
        }
    }
}
