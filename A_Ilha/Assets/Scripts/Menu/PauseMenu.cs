using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button resumePlay;

    private void Start()
    {
        resumePlay.onClick.AddListener(ResumeGame);
    }


    private static void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }
}