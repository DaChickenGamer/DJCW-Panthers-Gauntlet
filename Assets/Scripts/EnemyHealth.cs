using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : EnemyValues
{
    public Slider slider;
    private void Start()
    {
        enemyHealth = enemyMaxHealth;
        SetMaxHealth(enemyMaxHealth);
    }
    public void TakeDamage(int damage)
    {

        enemyHealth -= damage;
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0)
        {
            Debug.Log("Knockout");

            SceneManager.LoadScene(3); Destroy(gameObject);
        }
        SetHealth(enemyHealth);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(10);
    }
}
