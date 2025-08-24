using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBattleSceneButton : MonoBehaviour
{
    public void OnClickToBattleSceneButton()
    {
        SceneManager.LoadScene("Battle");
    }
}
