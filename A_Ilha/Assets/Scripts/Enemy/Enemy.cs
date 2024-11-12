using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    [Header("States")]
    [SerializeField] public State CurrentState;
    [SerializeField] public EnemyAtackState EnemyAtackState;
    [SerializeField] public EnemyListeningState EnemyListeningState;
    
    
    [SerializeField] public GameObject Player;
    [SerializeField] public Rigidbody EnemyRB;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        EnemyRB = transform.gameObject.GetComponent<Rigidbody>();
        
        
        ChangeState(EnemyAtackState);
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