using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button resumePlay;

    void Start()
    {
        resumePlay.onClick.AddListener(ResumeGame);
    }


    private void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }
}