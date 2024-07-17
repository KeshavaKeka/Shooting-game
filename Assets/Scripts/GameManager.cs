using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    private float xPos = 13;
    private float zPos = 13;
    private float startTime = 1;
    private float intervalTime = 4.0f;
    private int number = 0;
    public int maxEnemies = 20;
    public PlayerController script;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    void Start()
    {
        if (enemy == null || script == null || gameOverText == null)
        {
            Debug.LogError("One or more GameObjects are not assigned in the Inspector!");
            return;
        }

        //isGameActive = true;
        InvokeRepeating("SpawnEnemy", startTime, intervalTime);
    }

    void Update()
    {

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Shoot()
    {
        if (script != null)
        {
            script.ShootArrow();
        }
    }

    void SpawnEnemy()
    {
        if (number < maxEnemies)
        {
            Vector3 sPos = new Vector3(Random.Range(-xPos, xPos), enemy.transform.position.y, Random.Range(0, zPos));
            Instantiate(enemy, sPos, enemy.transform.rotation);
        number++;
    }
        else
        {
            GameOver();
        }
    }
}