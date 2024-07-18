using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float attackRange = 3f;
    public float attackDamage = 10f;
    public float attackCooldown = 1f;

    private Transform wallTarget;
    private float attackTimer;
    private float range = 5.0f;
    private float rand;
    private Vector3 porPos;

    private float speed = 5;

    private Damage damage;

    void Start()
    {
        damage = GameObject.Find("Portugese").GetComponent<Damage>();
        wallTarget = GameObject.Find("Portugese").transform;
        rand = Random.Range(-range, range);
        porPos = new Vector3(wallTarget.transform.position.x + rand, wallTarget.transform.position.y, wallTarget.transform.position.z + 1);
        attackTimer = 0f;
    }

    void Update()
    {
        if (wallTarget != null)
        {
            float distanceToWall = Vector3.Distance(transform.position, porPos);

            if (distanceToWall <= attackRange)
            {
                if (attackTimer <= 0f)
                {
                    AttackWall();
                    attackTimer = attackCooldown;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                MoveTowardsWall();
            }
        }
    }

    void MoveTowardsWall()
    {
        transform.position = Vector3.MoveTowards(transform.position, porPos, speed * Time.deltaTime);
        // Add your movement code here (e.g., using a NavMeshAgent if you want more advanced movement)
    }

    void AttackWall()
    {
        damage.takeDamage();
    }
}