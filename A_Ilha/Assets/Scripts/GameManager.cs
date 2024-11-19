using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioGeral audioGeral;
    
    // Modelo Singleton
    [Header("Singleton")]
    public static GameManager Instance;
    public GameState State;
    
    [Header("Canvas")]
    public Canvas menuPause;
    public Canvas menuDead;
    public Canvas menuEnd;
    
    [Header("Player")]
    public Player player; 
    public Transform spawnPlayerCheckpoint;

    [Header("Enemy")]
    public Enemy enemy;

    [Header("Objetivos")]
    public ObjetivosFeitos objetivosFeitos = ObjetivosFeitos.NaoFezNada;
    
    
    private void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void RestartGame()
    {
        menuDead.gameObject.SetActive(false);
        menuEnd.gameObject.SetActive(false);
        player.transform.position = spawnPlayerCheckpoint.position;
        ResumeGame();
        player.ChangeState(player.PlayerMovementState);
        // setar player status 
        // setar posicao monstro e status 
        // setar objetivos 
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
        Time.timeScale = 0f;
        menuPause.gameObject.SetActive(true);
    }

    public void DeadPlayer()
    {
        enemy.ChangeState(enemy.EnemyListeningState);
        
        // reset temporario enquanto n tem a logica do quadrante 
        enemy.transform.position = new Vector3(530,8,213);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        State = GameState.Pause;
        Time.timeScale = 0f;
        menuDead.gameObject.SetActive(true);
    }
    
    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        State = GameState.Pause;
        Time.timeScale = 0f;
        menuEnd.gameObject.SetActive(true);
    }


    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        State = GameState.Action;
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
    
    public enum ObjetivosFeitos
    {
        NaoFezNada,
        ChegouNaAldeia,
        InvestigouCasas,
        ChegouNaIgreja,
        DesfezAltar,
        ChegouNaMansao,
        LigouEnergia,
        ChegouNaTorre
        
    }

}