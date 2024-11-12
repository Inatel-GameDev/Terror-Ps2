using UnityEngine;
using UnityEngine.UI;


public class RestartMenu : MonoBehaviour
{
    public Button respawn;

    private void Start()
    {
        respawn.onClick.AddListener(Respawn);    
    }


    private static void Respawn()
    {
        GameManager.Instance.RestartGame();
    }
}