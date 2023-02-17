using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KOBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    private void Update()
    {
        // Delete later when we have a gameManager Script
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        {
            slider = GameObject.Find("KOBar").GetComponent<Slider>();
            slider.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Gym"))
        {
            slider = GameObject.Find("KOBar").GetComponent<Slider>();
            slider.gameObject.SetActive(true);
        }
    }
}
