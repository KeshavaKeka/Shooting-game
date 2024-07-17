using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public int maxhealth = 100;
    //public int currentHealth;
    public GameObject enemy;
    private float xPos = 13;
    private float zpos = 13;
    private float startTime = 1;
    private float intervalTime = 4.0f;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startTime, intervalTime);
        //currentHealth = maxhealth;
        //healthbar.setMaxHealth(maxhealth);
    }

    //public void takeDamage()
    //{
    //    currentHealth -= 10;
    //    healthbar.setMaxHealth(currentHealth);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        Vector3 sPos = new Vector3(Random.Range(-xPos,xPos), enemy.transform.position.y, Random.Range(0,zpos));
        Instantiate(enemy, sPos, enemy.transform.rotation);
    }
}
