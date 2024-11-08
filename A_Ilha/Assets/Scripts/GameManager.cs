using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Modelo Singleton 
    public static GameManager Instance;
    public GameState State;    
    public Player player;
    public Canvas menuPause;

    private void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        State = GameState.Pause;
        //player.IsPaused = true;
        Time.timeScale = 0f;
        menuPause.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        State = GameState.Action;
        //player.IsPaused = false;
        Time.timeScale = 1f;
        menuPause.gameObject.SetActive(false);
    }


    public enum Scene
    {
        StartMenu,
        Mapa,
        End
    }


    public enum GameState
    {
        Pause,
        Action,
        Shop,
        Loading
    }

}