using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Rahhhsound;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Basepos;
    [SerializeField] private float ChaseSpeed = 13f;
    private Rigidbody rb;
    private bool isAttacking = false;
    private EnemyStatus State;
    enum EnemyStatus
    {
        Idle,
        Chasing,
        Attacking
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        State = EnemyStatus.Idle;
    }
   private void Update()
    {
       //transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void FixedUpdate()     
    {
        //transform.LookAt(Player.transform.position);
        float distanceBasePos = (Player.transform.position - Basepos.transform.position).magnitude;
        float distanceToPlayer = (Player.transform.position - rb.transform.position).magnitude;
        switch (State)
        {
            case EnemyStatus.Idle:
                if (distanceBasePos < 7f)
                {
                    State = EnemyStatus.Chasing;
                   // State = EnemyStatus.Distracted;
                }
                else
                {
                   rb.transform.position = Vector3.MoveTowards(rb.transform.position, Basepos.transform.position, ChaseSpeed * Time.deltaTime);
                }
                break;

            case EnemyStatus.Chasing:
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, Player.transform.position, ChaseSpeed * Time.deltaTime);
                if (distanceToPlayer < 3f) // start attacking if close enough
                {
                    State = EnemyStatus.Attacking;
                }
                if (distanceBasePos > 10f) // go back to idle if player is too far from base
                {
                    State = EnemyStatus.Idle;
                }
                break;

            case EnemyStatus.Attacking:
                //if (distanceToPlayer < 5f) // go back to idle if player is far enough
                //{
                //    State = EnemyStatus.Idle;
                //}
                isAttacking = true;
                break;

        }
        Debug.Log(State);
    }
    public void Coolsound()
    {
       Instantiate(Rahhhsound, transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(isAttacking == true)
        {
           collision.gameObject.GetComponent<Health>().TakeDamage(10);
           isAttacking = false;
        }
    }
}
