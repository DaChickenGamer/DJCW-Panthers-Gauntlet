using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string punch;
    private string kick;
    private string pause;
    private string grapple;
    private string interact;
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
