using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider slider;
    public static int health,MaxHealth=100;
    private void Start()
    {
        health=MaxHealth;
        SetMaxHealth(MaxHealth);
    }
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Debug.Log("Knockout");
            
            //Destroy(gameObject);
        }
        SetHealth(health);
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
