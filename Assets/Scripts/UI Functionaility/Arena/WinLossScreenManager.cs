using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossScreenManager : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyController _enemyController;

    [Header("Player Victory")]
    public GameObject victoryScreen;
    public Animator victoryAnim;

    [Header("Player Loss")]
    public GameObject lossScreen;
    public Animator lossAnim;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyController = FindObjectOfType<EnemyController>();
        Debug.Log("start");
    }

    private void Update()
    {
        Debug.Log("update");
        if (_enemyController.IsDead())
        {
            Debug.Log("Victory");
            victoryScreen.SetActive(true);
            victoryAnim.SetTrigger("Start");
        }

        if (_playerHealth.IsDead())
        {
            Debug.Log("Loss");
            lossScreen.SetActive(true);
            lossAnim.SetTrigger("Start");
        }
    }
   

}
