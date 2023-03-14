using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private UnityEvent PlayerKOEvent;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public static int currentHealth;
    private float damageDelay,damageTick, deathDelay, damageSpeed=45;
    private int damagetake=1;
    public KOBar koBar;
    // Start is called before the first frame update
    void Start()
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            damagetake+=damagetake;
            TakeDamage(damagetake);
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
            //Will set the Playerknockout panel active once 
            //the player KOBar reaches bellow zero and will destroy
            //the player object
            if (deathDelay <= 0)    
            {                          
                Destroy(gameObject);
                PlayerKOEvent.Invoke();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        damageDelay += damage;
    }
}
