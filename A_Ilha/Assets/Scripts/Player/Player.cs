using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("States")]
    [SerializeField] public State CurrentState;
    [SerializeField] public PlayerMovementState PlayerMovementState;
    [SerializeField] public PlayerDeadState PlayerDeadState;
    
    [SerializeField] private bool IsPaused;
    
    [Header("Inputs")]
    public PlayerInput _playerInput;
    public InputAction _movementAction;
    public Rigidbody rb;

    [Header("Item")] 
    private Item _itemAtual;

    public Item ItemAtual
    {
        get => _itemAtual;
        set => _itemAtual = value;
    }


    private void Start()
    {
        transform.position = GameManager.Instance.spawnPlayerCheckpoint.transform.position;
        rb = GetComponent<Rigidbody>();
        ChangeState(PlayerMovementState);
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["move"];
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

    public void Pause()
    {
    }

    public void ResumePlay()
    {
    }

    private void Kill()
    {
        ChangeState(PlayerDeadState);
        GameManager.Instance.DeadPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("morte"))
        {
            Kill();
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        switch (trigger.gameObject.tag)
        {
            case "checkpointSpawn":
                GameManager.Instance.spawnPlayerCheckpoint = trigger.gameObject.transform;
                break;
            case "EndGame":
                ChangeState(PlayerDeadState);
                GameManager.Instance.EndGame();
                break;
        }
    }
    
    
}