using UnityEngine;

namespace TiOKawa.Scripts.Presenter
{
    public abstract class MonoPresenter : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Init();
            SetupModel();
            SetupView();
            SubscribeView();
            
#if UNITY_EDITOR
            Debug.Log($"Initialized {name}", this);
#endif
        }

        protected virtual void Init(){}
        protected virtual void SetupModel(){}
        protected virtual void SetupView(){}
        protected virtual void SubscribeView(){}
    }
}
