using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] public State CurrentState;

    [SerializeField] public PlayerMovementState PlayerMovementState;
    
    [SerializeField] private bool IsPaused;
    public PlayerInput _playerInput;
    public InputAction _movementAction;

    //[SerializeField] public GameManager manager;
    public Rigidbody rb;
    //public Anim anim;


    private void Start()
    {
        //manager.ResumeGame();
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        //CurrentState = FreeWalkState;
        ChangeState(PlayerMovementState);
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["move"];
        CurrentState.Enter();
    }

    private void Update()
    {
        CurrentState.Do();
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.T)) manager.PauseGame();
        //if (Input.GetKeyDown(KeyCode.P)) ChangeState(DriveState);
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

    public void Pause()
    {
    }

    public void ResumePlay()
    {
    }
}