using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public List<GameObject> enemy = new List<GameObject>();
    public float spawnTime = 0.5f;
    public Transform spawnPoints;
    public int enemycount = 0;
    public Button nextwave;
    float timer;
    int waves = 0;
    void Update()
    {        
        timer += Time.deltaTime;
        while (enemycount < 10 && timer >= spawnTime)
        {
            Instantiate(enemy[waves], spawnPoints.position, spawnPoints.rotation);
            enemycount++;
            timer = 0;
        }

        if (PointsManager.killcount == 10)
        {
            nextwave.gameObject.SetActive(true);
        }
    }

    public void NextWave ()
    {
        enemycount = 0;
        PointsManager.killcount = 0;
        waves++;
        playerHealth.currentHealth = playerHealth.startingHealth;
    }
}
