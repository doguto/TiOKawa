using System;
using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine;

namespace TiOKawa.Scenes.Sample.Scripts.View
{
    public class SampleSceneView : MonoView
    {
        [SerializeField] SimpleButton button;

        public IObservable<Unit> OnLoadTestData => button.OnClicked;
    }
}