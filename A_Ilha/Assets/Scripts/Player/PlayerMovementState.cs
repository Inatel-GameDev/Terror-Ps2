using UnityEngine;


public class PlayerMovementState : State
{
    public Player Player;
    
    
    [Header("Input")]
    private Vector2 _movementInput;
    
    [Header("Movement")]
    [SerializeField] private float speed;
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

    private void SpeedControl()
    {
        var flatVelocity = new Vector3(Player.rb.velocity.x, 0, Player.rb.velocity.z);
        if (!(flatVelocity.magnitude > speed)) return;
        var limitedVelocity = flatVelocity.normalized * speed;
        Player.rb.velocity = new Vector3(limitedVelocity.x, Player.rb.velocity.y, limitedVelocity.z);
    }
    

    public override void Enter()
    {
        Player.rb.freezeRotation = true;
    }

    public override void Do()
    {
        MyInput();    
        SpeedControl();
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        if (_isGrounded)
        {
            Player.rb.drag = groundDrag;
        } else {
            Player.rb.drag = 0; 
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
