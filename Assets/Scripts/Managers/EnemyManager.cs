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
    public Text wavescount;
    public Text nextwaveinfo;
    float timer;
    int waves = 0;
    void Update()
    {
        int showwaves = waves + 1;
        wavescount.text = "第" + showwaves + "波";

        nextwaveinfo.text =   "敌人数据：" + '\n'
                            + "血量   " + enemy[waves + 1].GetComponent<EnemyHealth>().startingHealth + '\n'
                            + "赏金   " + enemy[waves + 1].GetComponent<EnemyHealth>().scoreValue + '\n'
                            + "伤害   " + enemy[waves + 1].GetComponent<EnemyAttack>().attackDamage + '\n'
                            + "点数   " + enemy[waves + 1].GetComponent<EnemyHealth>().propoint;
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
