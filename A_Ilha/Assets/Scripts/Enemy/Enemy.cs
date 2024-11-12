using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Rigidbody EnemyRB;
    [Header("States")]
    [SerializeField] public State CurrentState;
    [SerializeField] public EnemyAtackState EnemyAtackState;
    [SerializeField] public EnemyListeningState EnemyListeningState;
    [SerializeField] public EnemySniffingState EnemySniffingState;
    
    
    [Header("Player")]
    [SerializeField] public GameObject Player;
    [SerializeField] public float distanciaPlayer;



    private IEnumerator DecideState()
    {
        ChecaDistancia();
        yield return new WaitForSeconds(1f);
        switch (distanciaPlayer)
        {
            // aparentemente nao da pra usar variavela aqui no switch
            case > 100:
                ChangeState(EnemyListeningState);
                break;
            case > 40:
                ChangeState(EnemySniffingState);
                break;
            default:
                ChangeState(EnemyAtackState);
                break;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(DecideState());
    }
    
    public void ChecaDistancia(){
       
        distanciaPlayer = Vector3.Distance(Player.transform.position, transform.position);
    }
    
    
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        EnemyRB = transform.gameObject.GetComponent<Rigidbody>();      
        
        ChangeState(EnemyAtackState);
        StartCoroutine(DecideState());
    }

    private void Update()
    {
        CurrentState.Do();
    }

    private void FixedUpdate()
    {
        CurrentState.FixedDo();
    }

    private void LateUpdate()
    {
        CurrentState.LateDo();
    }

    public void ChangeState(State newState)
    {
        try
        {
            CurrentState.Exit();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        CurrentState = newState;
        CurrentState.Enter();
    }

}