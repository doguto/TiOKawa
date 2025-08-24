using UnityEngine;
using TiOKawa.Scripts.View;
using UniRx;
using UnityEngine.SceneManagement;

public class TitleScenePresenter : MonoBehaviour
{
    [SerializeField] SimpleButton startButton;

    void Start()
    {
        startButton.OnClicked
            .Subscribe(_ => OnStartButtonClicked())
            .AddTo(this);
    }

    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Battle");
    }
}