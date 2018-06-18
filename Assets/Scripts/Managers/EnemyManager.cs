using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 0.5f;
    public Transform spawnPoints;
    public int enemycount = 0;
    public Button nextwave;
    float timer;

    void Update()
    {        
        timer += Time.deltaTime;
        while (enemycount < 10 && timer >= spawnTime)
        {
            Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);
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
    }
}
