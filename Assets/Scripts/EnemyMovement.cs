using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject por;
    private float range = 5.0f;
    private float rand;
    private Vector3 porPos;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //script = GameObject.Find("SpawnManager").GetComponent<Enemy>();
        por = GameObject.Find("Portugese");
        rand = Random.Range(-range, range);
        porPos = new Vector3(por.transform.position.x + rand, por.transform.position.y, por.transform.position.z);
        dir = (porPos - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        transform.position += dir * speed * Time.deltaTime;
    }
}
