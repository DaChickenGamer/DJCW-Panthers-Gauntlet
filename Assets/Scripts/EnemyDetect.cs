using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    
    private int playerDamage = 1; // The damge the player does to the enemy
    private float delay = 0.05f; // The delay before the object gets destroyed

    void Update()
    {
        if(delay >= 0)delay -= Time.deltaTime;
        if(delay <= 0)Destroy(gameObject);
    }
    public void OnTriggerStay2D(Collider2D collider)
    {
        EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy found");
            enemy.TakeDamage(playerDamage);
        }
    }
}
