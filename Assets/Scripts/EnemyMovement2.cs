//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyMovement2 : MonoBehaviour
//{
    //private float speed;
    //private GameObject player;
    //private Vector3 porPos;
    //private Vector3 dir;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    speed = Random.Range(5, 8);
    //    player = GameObject.Find("Player");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    dir = (player.transform.position - transform.position).normalized;
    //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    //    transform.position += dir * speed * Time.deltaTime;
    //}

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

    private Damage damage;

    void Start()
    {
        damage = GameObject.Find("Player").GetComponent<Damage>();
        playerTarget = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        attackTimer = 0f;
    }

    void Update()
    {
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

