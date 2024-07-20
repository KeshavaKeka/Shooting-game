using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
    public float attackRange = 2f;
    //public float attackDamage = 10f;
    public float attackCooldown = 1f;
    public float speed = 5;

    private Transform playerTarget;
    private NavMeshAgent navMeshAgent;
    private float attackTimer;

    private float minX = -13;
    private float maxX = 13;
    private float minZ = -12;
    private float maxZ = 13;
    private float ypos;

    private Damage damage;

    private Rigidbody rigidBody;
    void Start()
    {
        ypos = gameObject.transform.position.y;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        damage = GameObject.Find("Player").GetComponent<Damage>();
        playerTarget = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        attackTimer = 0f;
    }

    void Update()
    {
        float clampedX = Mathf.Clamp(rigidBody.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(rigidBody.position.z, minZ, maxZ);
        rigidBody.position = new Vector3(clampedX, ypos, clampedZ);
        if (playerTarget != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

            if (distanceToPlayer <= attackRange)
            {
                if (attackTimer <= 0f)
                {
                    AttackPlayer();
                    attackTimer = attackCooldown;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        //Debug.Log("Moving towards player");
        Vector3 dir = (playerTarget.position - transform.position).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        transform.position += dir * speed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        damage.takeDamagePlayer();
    }
}

