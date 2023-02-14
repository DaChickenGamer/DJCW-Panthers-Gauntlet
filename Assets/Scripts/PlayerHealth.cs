using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public KOBar kOBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        kOBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;

            kOBar.SetHealth(currentHealth);
        }
    }
}
