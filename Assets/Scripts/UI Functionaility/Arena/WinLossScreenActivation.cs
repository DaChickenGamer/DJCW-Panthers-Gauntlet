using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossScreenActivation : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyController _enemyController;
    public GameObject victoryScreen;
    public Animator victoryAnim;


    //GameObject lossScreen;
    //public Animation lossAnim;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyController = FindObjectOfType<EnemyController>();
        Debug.Log("start");
    }

    private void Update()
    {
        Debug.Log("update");
        if (_enemyController._isDead == true)
        {
            Debug.Log("Victory");
            victoryScreen.SetActive(true);
            victoryAnim.SetTrigger("Start");
        }
    }
   

}
