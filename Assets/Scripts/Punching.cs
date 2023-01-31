using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{
    private int damage = 5;
    void OnTriggerStay2D(Collider2D collider)
    {
        EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
        if (Input.GetMouseButton(0))
        {
            Debug.Log("pressed");
            if (collider.gameObject.tag == "Enemy")
            {
                Debug.Log("enemy found");
                enemy.TakeDamage(damage);
            }
        }
    }
}
