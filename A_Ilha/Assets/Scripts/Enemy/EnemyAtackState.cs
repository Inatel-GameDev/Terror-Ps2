using UnityEngine;

public class EnemyAtackState : State
{

    [SerializeField] private Enemy _enemy;
    [SerializeField] private float speed = 5f;


    public override void Enter()
    {

    }

    public override void Do()
    {
        _enemy.EnemyRB.AddForce((_enemy.Player.transform.position  - transform.position).normalized * speed, ForceMode.Impulse);
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