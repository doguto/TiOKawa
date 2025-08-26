using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace TiOKawa.Scenes.Title.Scripts.View
{
    public class ToBattleSceneButton : MonoBehaviour
    {
        private const string BattleSceneName = "Battle";
        public void OnClickToBattleSceneButton()
        {
            SceneManager.LoadScene(BattleSceneName);
        }
    }
}
