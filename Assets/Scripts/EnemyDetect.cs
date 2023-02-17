using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public GameObject Attack;
    private int damage = 5;
    private float delay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delay >= 0)delay -= Time.deltaTime;
        if(delay <= 0)Destroy(Attack);
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy found");
            enemy.TakeDamage(damage);
        }
    }
}
