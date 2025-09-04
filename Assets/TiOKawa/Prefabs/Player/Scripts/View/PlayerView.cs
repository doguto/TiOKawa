using TiOKawa.Scripts.View;

namespace TiOKawa.Prefabs.Player.Scripts.View
{
    public class PlayerView : MonoView
    {
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
