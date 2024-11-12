using UnityEngine;


public class PlayerMovementState : State
{
    public Player Player;
    
    
    [Header("Input")]
    private Vector2 _movementInput;
    
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Transform orientation;
    [SerializeField] private Vector3 direction;
    
    [Header("Ground")] 
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask groundLayer;
    private bool _isGrounded;
    [SerializeField] private float groundDrag;
    

    private void MyInput()
    {
        _movementInput = Player._movementAction.ReadValue<Vector2>();
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.PauseGame();
        }
    }

   private void MovePlayer() {
        
        direction = orientation.forward * _movementInput.y + orientation.right * _movementInput.x;
        Player.rb.AddForce(direction.normalized * (speed * 10f), ForceMode.Force);
    }

    public override void Enter()
    {
        Player.rb.maxLinearVelocity = maxSpeed;
        Player.rb.freezeRotation = true;
    }

    public override void Do()
    {
        MyInput();    
        
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        if (_isGrounded)
        {
            Player.rb.linearDamping = groundDrag;
        } else {
            Player.rb.linearDamping = 0; 
        }
    }

    public override void FixedDo()
    {
        MovePlayer();
    }

    public override void LateDo()
    {
        //throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }
}
