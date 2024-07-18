using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    public GameManager gamemanager;
    private bool isTakingDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        healthbar.setMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gamemanager.GameOver();
        }
    }

    public void takeDamage()
    {
        Debug.Log("Taking Damage");
        currentHealth -= 1;
        healthbar.setHealth(currentHealth);
    }
}
