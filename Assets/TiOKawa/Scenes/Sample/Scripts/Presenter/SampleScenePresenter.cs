using TiOKawa.Scenes.Sample.Scripts.Model;
using TiOKawa.Scenes.Sample.Scripts.View;
using TiOKawa.Scripts.Presenter;
using UniRx;
using UnityEngine;

namespace TiOKawa.Scenes.Sample.Scripts.Presenter
{
    public class SampleScenePresenter : MonoPresenter
    {
        [SerializeField] SampleSceneView sampleSceneView;
        [SerializeField] TestObjectView testObjectView;
        
        SampleTestDataModel sampleTestDataModel;
        

        protected override void SetupModel()
        {
            sampleTestDataModel = new SampleTestDataModel();
        }

        protected override void SetupView()
        {
            testObjectView.Init();
        }

        protected override void SubscribeView()
        {
            sampleSceneView.OnLoadTestData.Subscribe(SetupTestData);
        }

        void SetupTestData(Unit _)
        {
            testObjectView.Setup(sampleTestDataModel.Id, sampleTestDataModel.Name);   
        }
    }
}