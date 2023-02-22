using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private float damageDelay,damageTick;
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
        if(damageDelay > 0)
        {
            damageDelay-=40*Time.deltaTime;
            damageTick+=40*Time.deltaTime;
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
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }

    public void TakeDamage(int damage)
    {
        damageDelay += damage;
    }
}
