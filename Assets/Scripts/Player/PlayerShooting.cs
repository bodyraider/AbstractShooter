using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerShooting : MonoBehaviour
{
    PlayerStatus playerstatus;
    public int damagePerShot;
    public float timeBetweenBullets = 1f;
    public List<GameObject> enemy = new List<GameObject>();
    Transform playertrans;
    public GameObject player;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake ()
    {       
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        playertrans = GetComponentInParent<Transform> ();
    }


    void Update ()
    {
        playerstatus = player.GetComponent<PlayerStatus>();
        damagePerShot = playerstatus.atk;
        timeBetweenBullets = 100f / playerstatus.atkspeed;
        timer += Time.deltaTime;
        if (enemy.Count != 0)
        {
            if (enemy[0] == null)
            {
                UpdateEnemy();
            }           
            if (enemy.Count != 0)
            {
                SlowlyTurn();
            }
            if (timer >= timeBetweenBullets && Time.timeScale != 0 && enemy.Count != 0)
            {
                if (enemy[0] != null)
                    Shoot();
            }

            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                DisableEffects();
            }
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();
        /*
        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
        */
        EnemyHealth enemyHealth = enemy[0].GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(damagePerShot, shootHit.point);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy.Remove(other.gameObject);
        }
    }
    void UpdateEnemy()
    {
        List<int> emptyIndex = new List<int>();
        for (int index = 0;index < enemy.Count;index ++)
        {
            if (enemy[index] == null)
            {
                emptyIndex.Add(index);               
            }
        }

        for (int i = 0;i <emptyIndex.Count; i++)
        {
            enemy.RemoveAt(emptyIndex[i] - i);
        }
    }
    void SlowlyTurn()
    {
        Vector3 direction = enemy[0].transform.position - player.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotation, Time.deltaTime*10);
    }
}
