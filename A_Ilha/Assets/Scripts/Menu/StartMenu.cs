using UnityEngine;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    public Button newGame;

    private void Start()
    {
        newGame.onClick.AddListener(StartNewGame);    
    }


    private static void StartNewGame()
    {
        GameManager.Instance.LoadScene(GameManager.Scene.Mapa);
    }
}