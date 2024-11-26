using UnityEngine;

public class EnemyListeningState : State
{

    [SerializeField] private Enemy _enemy;

    [SerializeField] private Vector3[] Matriz;
    

    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float maxSpeed = 0.5f;
    //Não descomentar linhas a baixo
    public override void Enter()
    {
        
        //Matriz = new Vector3[60];
        //GerarMatriz();
    }

    public override void Do()
    {
        
    }

    public override void FixedDo()
    {
         /*   int j = 1;
            Debug.Log(j+" x:"+Matriz[j].x+" y:"+Matriz[j].y+" z:"+Matriz[j].z);
        while(j!=0)
        {
            
            if(transform.position.x != Matriz[j].x && transform.position.z != Matriz[j].z)
            {
                _enemy.EnemyRB.AddForce((Matriz[j]  - transform.position).normalized * acceleration, ForceMode.Impulse);
            }
            else
            {
                j++;
            }*/
        
    }

    public override void LateDo()
    {
            
    }

     public override void Exit()
    {
            
    }
    /*
    
    private void GerarMatriz()
    {
        for(int i = 1;i<10;i++)
        {
            Debug.Log(i);
                Matriz[i] = new Vector3(Random.Range(1f, 40f), 1f, Random.Range(1f, 40f));
        }
         
    }*/
}

    

