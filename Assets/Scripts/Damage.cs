using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        healthbar.setMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            gamemanager.GameOver();
        }
    }

    public void takeDamage()
    {
        currentHealth -= 25;
        healthbar.setHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            takeDamage();
            Destroy(other.gameObject);
        }
    }
}
