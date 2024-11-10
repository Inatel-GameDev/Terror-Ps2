using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("State")]
    [SerializeField] public State CurrentState;
    [SerializeField] public PlayerMovementState PlayerMovementState;
    [SerializeField] public PlayerDeadState PlayerDeadState;
    
    [Header("Movement")]
    public PlayerInput _playerInput;
    public InputAction _movementAction;
    public Rigidbody rb;
    
    private void Start()
    {
        transform.position = GameManager.Instance.spawnPlayerCheckpoint.transform.position;
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
        Debug.Log("trocou estado - " + newState);
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
        Debug.Log("morreu");
        ChangeState(PlayerDeadState);
        GameManager.Instance.DeadPlayer();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("morte"))
        {
            Kill();
        }
        if (collision.gameObject.CompareTag("checkpointSpawn"))
        {
            GameManager.Instance.spawnPlayerCheckpoint = collision.gameObject.transform;
        }
    }
}