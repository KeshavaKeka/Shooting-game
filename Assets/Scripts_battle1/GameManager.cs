using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    private float xPos = 13;
    private float zPos = 13;
    private float startTime = 2.5f;
    private float intervalTime;
    private int number = 0;
    public int maxEnemies = 25;
    public PlayerController script;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelCompletedText;
    public TextMeshProUGUI names;
    public Damage damage;
    public Damage damage2;
    public Button shoot;
    public FixedJoystick joystick;
    public Button resume;
    public Button pause;
    public bool isGameActive;

    void Start()
    {
        if (script == null || gameOverText == null || damage == null || damage2 == null)
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
        if (damage.currentHealth <= 0 || damage2.currentPlayerHealth <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            isGameActive = false;
            shoot.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);
            pause.gameObject.SetActive(false);
            names.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
        }
        else if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isGameActive = false;
            shoot.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);
            pause.gameObject.SetActive(false);
            names.gameObject.SetActive(false);
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
        int index = Random.Range(0, 3) % 2;
        if (number < maxEnemies && isGameActive)
        {
            Vector3 sPos = new Vector3(Random.Range(-xPos, xPos), enemies[index].transform.position.y, Random.Range(0, zPos));
            Instantiate(enemies[index], sPos, enemies[index].transform.rotation);
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