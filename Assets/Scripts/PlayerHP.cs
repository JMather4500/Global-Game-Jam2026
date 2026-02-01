using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHP : MonoBehaviour
{
    public float health;
    public float maxHealth;

   public GameObject healthBarUI;

    public Slider PlayerHealth;

    void Start()
    {
        health = maxHealth;
        PlayerHealth.value = CalculateHealth();
    }

    void Update()
    {
        PlayerHealth.value = CalculateHealth();


       if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            health -= 1;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}