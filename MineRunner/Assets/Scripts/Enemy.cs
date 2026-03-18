using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Rahhhsound;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Basepos;
    [SerializeField] private float ChaseSpeed = 13f;
    private Rigidbody rb;
    private GameObject honey;
    private float Cooldowntime = 5f;
    private EnemyStatus State;
    enum EnemyStatus
    {
        Idle,
        Chasing,
        Distracted,
        Attacking
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        State = EnemyStatus.Idle;
    }
   private void Update()
    {
       transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void FixedUpdate()     
    {
        Cooldowntime -= Time.deltaTime;
        //transform.LookAt(Player.transform.position);
        float distanceBeeNest = (Player.transform.position - Basepos.transform.position).magnitude;
        float distanceToPlayer = (Player.transform.position - rb.transform.position).magnitude;
        switch (State)
        {
            case EnemyStatus.Idle:
                if (distanceBeeNest < 4f)
                {
                    State = EnemyStatus.Chasing;
                    State = EnemyStatus.Distracted;
                }
                else
                {
                   rb.transform.position = Vector3.MoveTowards(rb.transform.position, Basepos.transform.position, ChaseSpeed * Time.deltaTime);
                }
                break;

            case EnemyStatus.Chasing:
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, Player.transform.position, ChaseSpeed * Time.deltaTime);
                if (distanceToPlayer < 2f) // start attacking if close enough
                {
                    State = EnemyStatus.Attacking;
                }
                break;

            case EnemyStatus.Attacking:
                if (distanceToPlayer < 5f) // go back to idel if player is far enough
                {
                    State = EnemyStatus.Idle;
                }
               //lose a health
                break;
            case EnemyStatus.Distracted:
                if (honey != null)
                {
                    float distanceToHoney = (honey.transform.position - rb.transform.position).magnitude;
                    rb.transform.position = Vector3.MoveTowards(rb.transform.position, honey.transform.position, 3 * Time.deltaTime);
                    if (distanceToHoney < 1f)
                    {
                        if (Cooldowntime <= 0f)
                        {
                            State = EnemyStatus.Idle;
                            Cooldowntime = 5f;
                        }
                    }
                    if (distanceToPlayer < 2f) // start attacking if player comes close while distracted
                    {
                        State = EnemyStatus.Attacking;
                    }
                    if (distanceToPlayer < 3f) // start chasing if player comes close while distracted
                    {
                        State = EnemyStatus.Chasing;
                    }
                }
                break;

        }
    }
    public void Coolsound()
    {
       Instantiate(Rahhhsound, transform.position, Quaternion.identity);
    }
}
