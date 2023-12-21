using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossScreenActivation : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    public GameObject victoryScreen;
    public Animation victoryAnim;


    //GameObject lossScreen;
    //public Animation lossAnim;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if (_playerHealth.currentHealth <= 0)
        {
            Debug.Log("Victory");
            victoryScreen.SetActive(true);
            victoryAnim.Play();
        }


    }
   

}
