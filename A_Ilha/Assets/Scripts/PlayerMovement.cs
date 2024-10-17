using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rb;
    
    [Header("Input")]
    private Vector2 _movementInput;
    private PlayerInput _playerInput;
    private InputAction _movementAction;
    
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private Transform orientation;
    [SerializeField] private Vector3 direction;
    
    [Header("Ground")] 
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask groundLayer;
    private bool _isGrounded;
    [SerializeField] private float groundDrag;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["move"];
    }

    private void MyInput()
    {
        _movementInput = _movementAction.ReadValue<Vector2>();
    }

   private void MovePlayer() {
        
        direction = orientation.forward * _movementInput.y + orientation.right * _movementInput.x;
        _rb.AddForce(direction.normalized * (speed * 10f), ForceMode.Force);
    }

    private void SpeedControl()
    {
        var flatVelocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        if (!(flatVelocity.magnitude > speed)) return;
        var limitedVelocity = flatVelocity.normalized * speed;
        _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        MyInput();    
        SpeedControl();
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        if (_isGrounded)
        {
            _rb.drag = groundDrag;
        } else {
            _rb.drag = 0; 
        }
    }
}
