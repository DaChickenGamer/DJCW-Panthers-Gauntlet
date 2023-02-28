using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    
    private int damage = 1;
    private float delay = 0.05f;

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
            enemy.TakeDamage(damage);
        }
    }
}
