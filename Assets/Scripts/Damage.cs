using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    public HealthBar playerbar;
    public GameManager gamemanager;
    public int playermaxhealth = 100;
    public int currentPlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = playermaxhealth;
        playerbar.setMaxHealth(playermaxhealth);
        currentHealth = maxhealth;
        healthbar.setMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 || currentPlayerHealth <=0)
        {
            gamemanager.GameOver();
        }
    }

    public void takeDamage()
    {
        currentHealth -= 1;
        healthbar.setHealth(currentHealth);
    }

    public void takeDamagePlayer()
    {
        currentPlayerHealth -= 5;
        playerbar.setHealth(currentPlayerHealth);
    }
}
