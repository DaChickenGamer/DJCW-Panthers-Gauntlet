using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    // Used to disable texture
    public Texture koBarTexture;

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
