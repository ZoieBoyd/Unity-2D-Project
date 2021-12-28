using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public Rigidbody2D rb;

    public AudioClip playerDeathSound;

    public Animator transition;
    public float transitionTime = 1.0f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        /*
         * Debug Code
         */
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }


        //Can be replaced with "Game Over" screen
        if (currentHealth <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Freezes player movement on death
            AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);

            StartCoroutine(ReloadLevel());
        }

    }
    IEnumerator ReloadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
