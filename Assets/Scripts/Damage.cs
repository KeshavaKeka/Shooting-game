using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Enemy script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("SpawnManager").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            script.takeDamage();
            Destroy(other.gameObject);
        }
    }
}
