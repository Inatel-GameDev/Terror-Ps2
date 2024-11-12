using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    // teste webhook
    [SerializeField] public State CurrentState;
    [SerializeField] public EnemyAtackState EnemyAtackState;
    [SerializeField] public EnemyListeningState EnemyListeningState;





    private void Start()
    {

        ChangeState(EnemyAtackState);

        CurrentState.Enter();


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