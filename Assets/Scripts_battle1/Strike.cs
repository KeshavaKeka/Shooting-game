using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private bool allowStrike = false;
    private Transform player;
    public List<Collider> otherObj = new List<Collider>();
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (otherObj.Count == 0)
        {
            allowStrike = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            otherObj.Add(other);
            allowStrike = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        otherObj.Remove(other);
    }

    public void StrikeEnemy()
    {
        if(allowStrike && otherObj.Count!=0)
        {
            Debug.Log("Striking Enemy");
            Collider des = otherObj[0];
            otherObj.RemoveAt(0);
            Vector3 direction = des.transform.position - player.position;
            direction.y = 0;
            player.rotation = Quaternion.LookRotation(direction);
            Destroy(des.gameObject);
        }
    }
}
