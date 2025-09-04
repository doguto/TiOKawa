using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TiOKawa.Scenes.Result.Scripts.View
{
    public class ResultSceneView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI levelText;
        [SerializeField] TextMeshProUGUI diedTiokawaCountText;
        [SerializeField] TextMeshProUGUI defeatedEnemyCountText;
        [SerializeField] TextMeshProUGUI tiokawaCountText;

        public void ShowLevel(int level)
        {
            levelText.text = $"{level}";
        }

        public void ShowDiedTiokawaCount(int count)
        {
            diedTiokawaCountText.text = $"{count}";
        }

        public void ShowDefeatedEnemyCount(int count)
        {
            defeatedEnemyCountText.text = $"{count}";
        }

        public void ShowTiokawaCount(int count)
        {
            tiokawaCountText.text = $"{count}";
        }
    }     
}
