using UnityEngine;

public class EnemyListeningState : State
{

    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody EnemyRB;


    public override void Enter()
    {
        Player = GameObject.FindWithTag("Player");
        EnemyRB = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    public override void Do()
    {

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