using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyValues : MonoBehaviour
{

	
	[Header("Enemy Stats")]
    [SerializeField] protected int enemyDamage = 5;

    [SerializeField] protected static int enemyHealth;
    protected static int enemyMaxHealth = 100;

    [SerializeField] protected float speed = 4f;

    [Header("Enemy Grapple Settings")]
    // Make wincount higher for harder characters
    [SerializeField] protected int winCount = 10;

    // Makes the fight easier by giving the player a bigger saftey net
    [SerializeField] protected int failCount = -10;

    [SerializeField] protected float delay = 1f; // Delays the enemys grapple
}
