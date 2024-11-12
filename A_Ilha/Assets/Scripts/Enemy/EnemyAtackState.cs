using UnityEngine;

public class EnemyAtackState : State
{

    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody EnemyRB;
    [SerializeField] private float speed = 0.5f;


    public override void Enter()
    {
        Player = GameObject.FindWithTag("Player");
        EnemyRB = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    public override void Do()
    {
            EnemyRB.AddForce((Player.transform.position  - transform.position).normalized * speed, ForceMode.Impulse);

    }

    public override void FixedDo()
    {
            
    }

    public override void LateDo()
    {
            
    }

     public override void Exit()
    {
            
    }
}