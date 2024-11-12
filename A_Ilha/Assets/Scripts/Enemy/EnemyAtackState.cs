using UnityEngine;

public class EnemyAtackState : State
{

    [SerializeField] private Enemy _enemy;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;


    public override void Enter()
    {
        _enemy.EnemyRB.maxLinearVelocity= maxSpeed;
    }

    public override void Do()
    {
        _enemy.EnemyRB.AddForce((_enemy.Player.transform.position  - transform.position).normalized * acceleration, ForceMode.Impulse);
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