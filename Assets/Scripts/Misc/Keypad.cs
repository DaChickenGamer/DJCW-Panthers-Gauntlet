using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public bool showConsole;
    public bool consoleEnabled; // Lets you use the keybind to use the console now

    public TMP_InputField charHolder;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;
    public GameObject clearButton;
    public GameObject enterButton;

    public void b1()
    {
        charHolder.text += "1";
    }
    public void b2()
    {
        charHolder.text += "2";
    }
    public void b3()
    {
        charHolder.text += "3";
    }
    public void b4()
    {
        charHolder.text += "4";
    }
    public void b5()
    {
        charHolder.text += "5";
    }
    public void b6()
    {
        charHolder.text += "6";
    }
    public void b7()
    {
        charHolder.text += "7";
    }
    public void b8()
    {
        charHolder.text += "8";
    }
    public void b9()
    {
        charHolder.text += "9";
    }
    public void b0()
    {
        charHolder.text += "0";
    }
    public void ClearEvent()
    {
        charHolder.text = null;
    }
    public void EnterEvent() // Triggers events based on number
    {
        if (charHolder.text == "1234")
        {
            Debug.Log("Nice Test Code!");
        }
        else if (charHolder.text == "3444334666")
        {
            Debug.Log("I'm Gay!");
        }
        else if (charHolder.text == "42999")
        {
            showConsole = !showConsole;
            Debug.Log("Console Popped Up");
            Debug.Log(showConsole);
        }
        else
        {
            Debug.Log("Failed");
        }
        charHolder.text = null;
    }
}
