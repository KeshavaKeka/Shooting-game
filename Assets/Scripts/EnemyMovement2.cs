using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    private float speed;
    private GameObject player;
    private Vector3 porPos;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5, 8);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dir = (player.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        transform.position += dir * speed * Time.deltaTime;
    }
}
