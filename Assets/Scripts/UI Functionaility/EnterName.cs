using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class EnterName : MonoBehaviour
{
    public static string playerName="";
    public GameObject Display, NameBox;
    private void Start()
    {
        playerName= PlayerPrefs.GetString("PlayerName");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            NameBox.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("PlayerName");
        }
    }
    public void NamePlayer(string s)
    {
        playerName = s;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        if (playerName.ToLower() == "diego")
        {
            Display.SetActive(true);
        }
    }
}
