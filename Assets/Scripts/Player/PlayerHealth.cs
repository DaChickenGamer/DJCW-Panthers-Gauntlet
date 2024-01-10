using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.Device;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    private float damageDelay,damageTick, deathDelay, damageSpeed=45;
    public KOBar koBar;
    public bool onReturnActive; // TESTING CONSOLE SYSTEM

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        koBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (deathDelay > 0)
        {
            deathDelay -= Time.deltaTime;
        }
        if(damageDelay > 0)
        {
            damageDelay-=damageSpeed*Time.deltaTime;
            damageTick+=damageSpeed*Time.deltaTime;
        }

        if(damageTick >= 1)
        {
            damageTick--;
            currentHealth--;
            koBar.SetHealth(currentHealth);
        }
        if(currentHealth <= 0)
        {
            if (deathDelay == 0)
            {
                deathDelay = 4;
            }
            
        }
    }
    public void OnReturn(InputValue value) // Used For Inputs In Console
    {
        onReturnActive = !onReturnActive;
    }
    public void TakeDamage(int damage)
    {
        damageDelay += damage;
    }
    public void IncreaseHealth() // Used for Console
    {
        maxHealth += 100;
        Debug.Log("Current Health" + maxHealth);
        currentHealth +=100;
        koBar.SetMaxHealth(maxHealth);
    }

    //Check if Player is dead
    public bool IsDead()
    {
        if (!(currentHealth < 1))
            return false;
        return true;
    }
}
