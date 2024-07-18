using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    private float xPos = 13;
    private float zPos = 13;
    private float startTime = 2.5f;
    private float intervalTime;
    private int number = 0;
    public int maxEnemies = 20;
    public PlayerController script;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelCompletedText;
    public Damage damage;
    public Button shoot;
    public FixedJoystick joystick;
    public Button resume;
    public Button pause;
    public bool isGameActive;

    void Start()
    {
        if (enemy == null || script == null || gameOverText == null || damage == null)
        {
            Debug.LogError("One or more GameObjects are not assigned in the Inspector!");
            return;
        }
        isGameActive = true;
        Invoke("SpawnEnemy", startTime);
    }

    void Update()
    {

    }

    public void Pause()
    {
        pause.gameObject.SetActive(false);
        resume.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        resume.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        isGameActive = false;
        shoot.gameObject.SetActive(false);
        joystick.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        if (damage.currentHealth <= 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            levelCompletedText.gameObject.SetActive(true);
        }
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
        if (number < maxEnemies && isGameActive)
        {
            Vector3 sPos = new Vector3(Random.Range(-xPos, xPos), enemy.transform.position.y, Random.Range(0, zPos));
            Instantiate(enemy, sPos, enemy.transform.rotation);
            number++;
            float nextInvoke = Random.Range(1, 3);
            Invoke("SpawnEnemy", nextInvoke);
        }
        else
        {
            GameOver();
        }
    }
}