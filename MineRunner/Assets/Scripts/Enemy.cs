using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Rahhhsound;
    [SerializeField] private GameObject Basepos;
    [SerializeField] private float ChaseSpeed = 13f;
    [SerializeField] private Animator anim;
    private Rigidbody rb;
    private PlayerController Player;
    private EnemyStatus State;
    private float turn_speed = 5f;
    private float CooldownAttack = 1.8f;
    private float x, y, z;
    enum EnemyStatus
    {
        Idle,
        Chasing,
        Attacking
    }
    private void Start()
    {
        Player = FindFirstObjectByType<PlayerController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        State = EnemyStatus.Idle;

        // Set random position for the enemy to return to when idle
        x = Random.Range(-10, 10f);
        y = 3.08f;
        z = Random.Range(-10f, 10f);

        x += transform.position.x;
        y += transform.position.y;
        z += transform.position.z;

        Basepos.transform.position = new Vector3(x, y, z);
    }
    private void Update()
    {

        if (State == EnemyStatus.Chasing || State == EnemyStatus.Attacking)
        {
            LookAtPlayer();
        }
        else
        {
            if (Vector3.Distance(transform.position, Basepos.transform.position) < 0.5f)
            {
                anim.SetBool("Walking", false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                anim.SetBool("Walking", true);
                Quaternion _lookRotation =
                 Quaternion.LookRotation((Basepos.transform.position - transform.position).normalized);

                //over time
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);
            }
        }
    }
    private void FixedUpdate()     
    {
        Basepos.transform.position = new Vector3(x, y, z);
        CooldownAttack -= Time.deltaTime;
        float distanceBasePos = (Player.transform.position - Basepos.transform.position).magnitude;
        float distanceToPlayer = (Player.transform.position - rb.transform.position).magnitude;
        switch (State)
        {
            case EnemyStatus.Idle:
                anim.SetBool("Walking", false);
                anim.SetBool("Attack", false);
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
                anim.SetBool("Walking", true);
                anim.SetBool("Attack", false);
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, Player.transform.position, ChaseSpeed * Time.deltaTime);

                if (distanceToPlayer < 2.8f) // start attacking if close enough
                {
                    State = EnemyStatus.Attacking;
                }

                if (distanceToPlayer > 6f) // go back to idle if player is far enough
                {
                    State = EnemyStatus.Idle;
                }
                break;

            case EnemyStatus.Attacking:
                anim.SetBool("Walking", false);
                anim.SetBool("Attack", true);
                if (distanceToPlayer > 4f) // go back to chasing if player is far enough
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Walking", true);
                    State = EnemyStatus.Chasing;
                }
                    break;
        }
    }
    public void Coolsound()
    {
       Instantiate(Rahhhsound, transform.position, Quaternion.identity);
    }
    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.CompareTag("Player") && CooldownAttack <= 0f)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(10);
            CooldownAttack = 1f; // reset cooldown
        }
    }
    private void LookAtPlayer()
    {
        Quaternion _lookRotation =
            Quaternion.LookRotation((Player.transform.position - transform.position).normalized);

        //over time
        transform.rotation =
            Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);
    }
}
