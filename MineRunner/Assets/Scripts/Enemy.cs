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
    private float turn_speed = 5f;
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

        Quaternion _lookRotation =
            Quaternion.LookRotation((Player.transform.position - transform.position).normalized);

        //over time
        transform.rotation =
            Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);
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
                }
                else
                {
                   rb.transform.position = Vector3.MoveTowards(rb.transform.position, Basepos.transform.position, ChaseSpeed * Time.deltaTime);
                }

                if (distanceToPlayer < 3f) // start attacking if close enough
                {
                    State = EnemyStatus.Attacking;
                }
                break;

            case EnemyStatus.Chasing:
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, Player.transform.position, ChaseSpeed * Time.deltaTime);
                if (distanceToPlayer < 3f) // start attacking if close enough
                {
                    State = EnemyStatus.Attacking;
                }
                break;

            case EnemyStatus.Attacking:
                isAttacking = true;
                //if (distanceToPlayer < 8f) // go back to idle if player is far enough
                //{
                //    State = EnemyStatus.Idle;
                //}
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
