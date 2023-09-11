using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class SpriteManager : MonoBehaviour
{
    private static SpriteManager instance;
    public static SpriteManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpriteManager>();
            }
            return instance;
        }
    }
    public GameObject upimage, leftimage, downimage, rightimage, punchimage, kickimage, grappleimage, interactimage, pauseimage;
    public Sprite UP, LEFT, DOWN, RIGHT, 
        PUNCH, KICK, GRAPPLE, INTERACT, PAUSE;
    public static int UpInput, LeftInput, DownInput, RightInput,
        PunchInput, KickInput, GrappleInput, InteractInput, PauseInput, ImageHolder, PlaceHolder;
    public Sprite[] KeyboardKeyBinds;
    private float ImageDelay;
    private bool ImageChange=true;
    public static bool CanChange = false;
    public void ImageBinding(string name, string binding)
    {
        
        Debug.Log(name + " " + binding);
        if (name.Contains("ACT"))//removes the act at the end of the action keys
        {
            name = name.Replace("ACT", "");
        }
        if (name.Equals("INTER"))//adds act back onto the end on interact
        {
            name = name.Replace("INTER", "INTERACT");
        }
        if(binding.Contains(" "))//makes sure there are no spaces in the binding
        {
            binding = binding.Replace(" ", "");
        }
            switch (binding)//finds the binding that is used for the key
            {
                case "0":
                    PlaceHolder = 1 + ImageHolder;
                    break;
                case "1":
                    PlaceHolder = 3 + ImageHolder;
                    break;
                case "2":
                    PlaceHolder = 5 + ImageHolder;
                    break;
                case "3":
                    PlaceHolder = 7 + ImageHolder;
                    break;
                case "4":
                    PlaceHolder = 9 + ImageHolder;
                    break;
                case "5":
                    PlaceHolder = 11+ImageHolder;
                    break;
                case "6":
                    PlaceHolder = 13+ImageHolder;
                    break;
                case "7":
                    PlaceHolder = 15+ImageHolder;
                    break;
                case "8":
                    PlaceHolder = 17+ImageHolder;
                    break;
                case "9":
                    PlaceHolder = 19+ImageHolder;
                    break;
                case "A":
                    PlaceHolder = 21+ImageHolder;
                    break;
                case "Quote":
                    PlaceHolder = 23+ImageHolder;
                    break;
                case "DownArrow":
                    PlaceHolder = 25+ImageHolder;
                    break;
                case "LeftArrow":
                    PlaceHolder = 27+ImageHolder;
                    break;
                case "RightArrow":
                    PlaceHolder = 29+ImageHolder;
                    break;
                case "UpArrow":
                    PlaceHolder = 31+ImageHolder;
                    break;
                case "B":
                    PlaceHolder = 33+ImageHolder;
                    break;
                case "LeftBracket":
                    PlaceHolder = 35+ImageHolder;
                    break;
                case "RightBracket":
                    PlaceHolder = 37+ImageHolder;
                    break;
                case "C":
                    PlaceHolder = 39+ImageHolder;
                    break;
                case "Comma":
                    PlaceHolder = 41+ImageHolder;
                    break;
                case "D":
                    PlaceHolder = 43+ImageHolder;
                    break;
                case "Minus":
                    PlaceHolder = 45+ImageHolder;
                    break;
                case "E":
                    PlaceHolder = 47+ImageHolder;
                    break;
                case "Equals":
                    PlaceHolder = 49+ImageHolder;
                    break;
                case "Escape":
                    PlaceHolder = 51+ImageHolder;
                    break;
                case "F":
                    PlaceHolder = 53+ImageHolder;
                    break;
                case "G":
                    PlaceHolder = 55+ImageHolder;
                    break;
                case "H":
                    PlaceHolder = 57+ImageHolder;
                    break;
                case "I":
                    PlaceHolder = 59+ImageHolder;
                    break;
                case "J":
                    PlaceHolder = 61+ImageHolder;
                    break;
                case "K":
                    PlaceHolder = 63+ImageHolder;
                    break;
                case "L":
                    PlaceHolder = 65+ImageHolder;
                    break;
                case "M":
                    PlaceHolder = 67+ImageHolder;
                    break;
                case "N":
                    PlaceHolder = 69+ImageHolder;
                    break;
                case "O":
                    PlaceHolder = 71+ImageHolder;
                    break;
                case "P":
                    PlaceHolder = 73+ImageHolder;
                    break;
                case "Period":
                    PlaceHolder = 75+ImageHolder;
                    break;
                case "Q":
                    PlaceHolder = 77+ImageHolder;
                    break;
                case "R":
                    PlaceHolder = 79+ImageHolder;
                    break;
                case "S":
                    PlaceHolder = 81+ImageHolder;
                    break;
                case "Semicolon":
                    PlaceHolder = 83+ImageHolder;
                    break;
                case "Slash":
                    PlaceHolder = 85+ImageHolder;
                    break;
                case "Backslash":
                    PlaceHolder = 87+ImageHolder;
                    break;
                case "T":
                    PlaceHolder = 89+ImageHolder;
                    break;
                case "U":
                    PlaceHolder = 91+ImageHolder;
                    break;
                case "V":
                    PlaceHolder = 93+ImageHolder;
                    break;
                case "W":
                    PlaceHolder = 95+ImageHolder;
                    break;
                case "X":
                    PlaceHolder = 97+ImageHolder;
                    break;
                case "Y":
                    PlaceHolder = 99+ImageHolder;
                    break;
                case "Z":
                    PlaceHolder = 101+ImageHolder;
                    break;
                case "LeftClick":
                    PlaceHolder = 103+ImageHolder;
                    break;
                case "MiddleClick":
                    PlaceHolder = 105+ImageHolder;
                    break;
                case "RightClick":
                    PlaceHolder = 107+ImageHolder;
                    break;
                default:
                    PlaceHolder=1+ImageHolder;
                break;
        }
        if (name == "UP") { UpInput = PlaceHolder; }//finds the key that is being replaced
        if (name == "LEFT") { LeftInput = PlaceHolder; }
        if (name == "DOWN") { DownInput = PlaceHolder; }
        if (name == "RIGHT") { RightInput = PlaceHolder; }
        if (name == "PUNCH") { PunchInput = PlaceHolder; }
        if (name == "KICK") { KickInput = PlaceHolder; }
        if (name == "GRAPPLE") { GrappleInput = PlaceHolder; }
        if (name == "INTERACT") { InteractInput = PlaceHolder; }
        if (name == "PAUSE") { PauseInput = PlaceHolder; }
        CanChange = true;
    }
    // Start is called before the first frame update

    void Awake()
    {
        CanChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageDelay > 0)
        {
            ImageDelay -= Time.deltaTime;
        }
        UP = KeyboardKeyBinds.ElementAt(UpInput);//the images are constatly updating
        LEFT = KeyboardKeyBinds.ElementAt(LeftInput);
        DOWN = KeyboardKeyBinds.ElementAt(DownInput);
        RIGHT = KeyboardKeyBinds.ElementAt(RightInput);
        PUNCH = KeyboardKeyBinds.ElementAt(PunchInput);
        KICK = KeyboardKeyBinds.ElementAt(KickInput);
        GRAPPLE = KeyboardKeyBinds.ElementAt(GrappleInput);
        INTERACT = KeyboardKeyBinds.ElementAt(InteractInput);
        PAUSE = KeyboardKeyBinds.ElementAt(PauseInput);
        upimage.GetComponent<SpriteRenderer>().sprite = UP;
        leftimage.GetComponent<SpriteRenderer>().sprite = LEFT;
        downimage.GetComponent<SpriteRenderer>().sprite = DOWN;
        rightimage.GetComponent<SpriteRenderer>().sprite = RIGHT;
        punchimage.GetComponent<SpriteRenderer>().sprite = PUNCH;
        kickimage.GetComponent<SpriteRenderer>().sprite = KICK;
        grappleimage.GetComponent<SpriteRenderer>().sprite = GRAPPLE;
        interactimage.GetComponent<SpriteRenderer>().sprite = INTERACT;
        pauseimage.GetComponent<SpriteRenderer>().sprite = PAUSE;
        if (ImageDelay <= 0&&CanChange)
        {
            if (ImageChange)//makes the keys flash
				{
                UpInput--;
                LeftInput--;
                DownInput--;
                RightInput--;
                PunchInput--;
                KickInput--;
                GrappleInput--;
                InteractInput--;
                PauseInput--;
                ImageChange = false;
                ImageDelay = 1;
                ImageHolder--;
            }
            else
            {
                UpInput++;
                LeftInput++;
                DownInput++;
                RightInput++;
                PunchInput++;
                KickInput++;
                GrappleInput++;
                InteractInput++;
                PauseInput++;
                ImageChange = true;
                ImageDelay = 1;
                ImageHolder++;
            }
        }
    }
}
