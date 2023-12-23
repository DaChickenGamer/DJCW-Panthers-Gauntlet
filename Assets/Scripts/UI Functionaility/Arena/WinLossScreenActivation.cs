using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossScreenActivation : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyValues _enemyValues;
    public GameObject victoryScreen;
    public Animator victoryAnim;


    //GameObject lossScreen;
    //public Animation lossAnim;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyValues = FindObjectOfType<EnemyValues>();
        Debug.Log("start");
    }

    private void Update()
    {
        Debug.Log("update");
        if (_enemyValues.enemyHealth < 1)
        {
            Debug.Log("Victory");
            victoryScreen.SetActive(true);
            victoryAnim.SetTrigger("Start");
        }
    }
   

}
