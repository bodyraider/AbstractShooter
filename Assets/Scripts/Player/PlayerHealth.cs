using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    PlayerStatus playerstatus;
    public int startingHealth;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Text healthamount;

    Animator anim;
    AudioSource playerAudio;   
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
    float timer;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        playerstatus = GetComponent<PlayerStatus>();
        startingHealth = playerstatus.health;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
        currentHealth = startingHealth;
    }


    void Update ()
    {
        startingHealth = playerstatus.health;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = currentHealth;
        timer += Time.deltaTime;
        healthamount.text = currentHealth.ToString();
        if (timer >= 1f && Time.timeScale != 0 && currentHealth > 0)
        {
            if (startingHealth - currentHealth >= playerstatus.healspeed)
            {
                currentHealth += playerstatus.healspeed;
            }
            else
                currentHealth = startingHealth;
            timer = 0f;

        }

        if (currentHealth < 0)   //防止血量溢出下限
            currentHealth = 0;
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        

        playerAudio.Play ();
        

        if (currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
