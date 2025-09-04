using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TiOKawa.Scenes.Result.Scripts.View
{
    public class ResultSceneView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI levelText;

        void Start()
        {
            ShowLevel(5);
        }

        public void ShowLevel(int level)
        {
            levelText.text = $"LEVEL: {level}";
        }
    }     
}
