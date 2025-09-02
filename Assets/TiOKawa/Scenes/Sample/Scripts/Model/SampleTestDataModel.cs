namespace TiOKawa.Scenes.Sample.Scripts.Model
{
    public class SampleTestDataModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        
        public SampleTestDataModel()
        {
            // サンプルデータとしてハードコーディング
            Id = 1;
            Name = "Sample Test Data";
        }
    }
}