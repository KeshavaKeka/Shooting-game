using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private bool allowStrike = false;
    private Transform player;
    public Queue<Collider> otherObj = new Queue<Collider>();
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            otherObj.Enqueue(other);
            allowStrike = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            allowStrike = false;
        }
    }

    public void StrikeEnemy()
    {
        if(allowStrike)
        {
            Debug.Log("Striking Enemy");
            Collider des = otherObj.Dequeue();
            player.LookAt(des.gameObject.transform);
            Destroy(des.gameObject);
        }
    }
}
