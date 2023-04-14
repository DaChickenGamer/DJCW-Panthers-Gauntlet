using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public static string punch;
    public static string kick;
    public static string pause;
    public static string grapple;
    public static string interact;
    public void Punch(string s)
    {
        punch = s;
    }
    public void Kick(string s)
    {
        kick = s;
    }
    public void Pause(string s)
    {
        pause = s;
    }
    public void Grapple(string s)
    {
        grapple = s;
    }
    public void Interact(string s)
    {
        interact = s;
    }
}
