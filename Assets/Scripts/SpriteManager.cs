using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject upi, lefti, downi, righti, punchi, kicki, grapplei, interacti, pausei;
    public Sprite UP, LEFT, DOWN, RIGHT, 
        PUNCH, KICK, GRAPPLE, INTERACT, PAUSE;
    public static int UpInput, LeftInput, DownInput, RightInput,
        PunchInput, KickInput, GrappleInput, InteractInput, PauseInput, ImageHolder;
    public Sprite[] KeyboardKeyBinds;
    private float ImageDelay;
    private bool ImageChange=true;
    public static bool CanChange = true;
    public void ImageBinding(string name, string binding)
    {
        Debug.Log(name + " " + binding);
        if (name.Contains("ACT"))
        {
            name = name.Replace("ACT", "");
        }
        if (name.Equals("INTER"))
        {
            name = name.Replace("INTER", "INTERACT");
        }
        if(binding.Contains(" "))
        {
            binding = binding.Replace(" ", "");
        }
        switch (name)
        {
            case "UP":
                switch (binding)
                {
                    case "0":
                        UpInput = 1 + ImageHolder;
                        break;
                    case "1":
                        UpInput = 3 + ImageHolder;
                        break;
                    case "2":
                        UpInput = 5 + ImageHolder;
                        break;
                    case "3":
                        UpInput = 7 + ImageHolder;
                        break;
                    case "4":
                        UpInput = 9 + ImageHolder;
                        break;
                    case "5":
                        UpInput = 11+ImageHolder;
                        break;
                    case "6":
                        UpInput = 13+ImageHolder;
                        break;
                    case "7":
                        UpInput = 15+ImageHolder;
                        break;
                    case "8":
                        UpInput = 17+ImageHolder;
                        break;
                    case "9":
                        UpInput = 19+ImageHolder;
                        break;
                    case "A":
                        UpInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        UpInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        UpInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        UpInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        UpInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        UpInput = 31+ImageHolder;
                        break;
                    case "B":
                        UpInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        UpInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        UpInput = 37+ImageHolder;
                        break;
                    case "C":
                        UpInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        UpInput = 41+ImageHolder;
                        break;
                    case "D":
                        UpInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        UpInput = 45+ImageHolder;
                        break;
                    case "E":
                        UpInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        UpInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        UpInput = 51+ImageHolder;
                        break;
                    case "F":
                        UpInput = 53+ImageHolder;
                        break;
                    case "G":
                        UpInput = 55+ImageHolder;
                        break;
                    case "H":
                        UpInput = 57+ImageHolder;
                        break;
                    case "I":
                        UpInput = 59+ImageHolder;
                        break;
                    case "J":
                        UpInput = 61+ImageHolder;
                        break;
                    case "K":
                        UpInput = 63+ImageHolder;
                        break;
                    case "L":
                        UpInput = 65+ImageHolder;
                        break;
                    case "M":
                        UpInput = 67+ImageHolder;
                        break;
                    case "N":
                        UpInput = 69+ImageHolder;
                        break;
                    case "O":
                        UpInput = 71+ImageHolder;
                        break;
                    case "P":
                        UpInput = 73+ImageHolder;
                        break;
                    case "Period":
                        UpInput = 75+ImageHolder;
                        break;
                    case "Q":
                        UpInput = 77+ImageHolder;
                        break;
                    case "R":
                        UpInput = 79+ImageHolder;
                        break;
                    case "S":
                        UpInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        UpInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        UpInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        UpInput = 87+ImageHolder;
                        break;
                    case "T":
                        UpInput = 89+ImageHolder;
                        break;
                    case "U":
                        UpInput = 91+ImageHolder;
                        break;
                    case "V":
                        UpInput = 93+ImageHolder;
                        break;
                    case "W":
                        UpInput = 95+ImageHolder;
                        break;
                    case "X":
                        UpInput = 97+ImageHolder;
                        break;
                    case "Y":
                        UpInput = 99+ImageHolder;
                        break;
                    case "Z":
                        UpInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        UpInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        UpInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        UpInput = 107+ImageHolder;
                        break;
                }
                break;
            case "LEFT":
                switch (binding)
                {
                    case "0":
                        LeftInput = 1 + ImageHolder;
                        break;
                    case "1":
                        LeftInput = 3 + ImageHolder;
                        break;
                    case "2":
                        LeftInput = 5 + ImageHolder;
                        break;
                    case "3":
                        LeftInput = 7 + ImageHolder;
                        break;
                    case "4":
                        LeftInput = 9 + ImageHolder;
                        break;
                    case "5":
                        LeftInput = 11+ImageHolder;
                        break;
                    case "6":
                        LeftInput = 13+ImageHolder;
                        break;
                    case "7":
                        LeftInput = 15+ImageHolder;
                        break;
                    case "8":
                        LeftInput = 17+ImageHolder;
                        break;
                    case "9":
                        LeftInput = 19+ImageHolder;
                        break;
                    case "A":
                        LeftInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        LeftInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        LeftInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        LeftInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        LeftInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        LeftInput = 31+ImageHolder;
                        break;
                    case "B":
                        LeftInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        LeftInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        LeftInput = 37+ImageHolder;
                        break;
                    case "C":
                        LeftInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        LeftInput = 41+ImageHolder;
                        break;
                    case "D":
                        LeftInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        LeftInput = 45+ImageHolder;
                        break;
                    case "E":
                        LeftInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        LeftInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        LeftInput = 51+ImageHolder;
                        break;
                    case "F":
                        LeftInput = 53+ImageHolder;
                        break;
                    case "G":
                        LeftInput = 55+ImageHolder;
                        break;
                    case "H":
                        LeftInput = 57+ImageHolder;
                        break;
                    case "I":
                        LeftInput = 59+ImageHolder;
                        break;
                    case "J":
                        LeftInput = 61+ImageHolder;
                        break;
                    case "K":
                        LeftInput = 63+ImageHolder;
                        break;
                    case "L":
                        LeftInput = 65+ImageHolder;
                        break;
                    case "M":
                        LeftInput = 67+ImageHolder;
                        break;
                    case "N":
                        LeftInput = 69+ImageHolder;
                        break;
                    case "O":
                        LeftInput = 71+ImageHolder;
                        break;
                    case "P":
                        LeftInput = 73+ImageHolder;
                        break;
                    case "Period":
                        LeftInput = 75+ImageHolder;
                        break;
                    case "Q":
                        LeftInput = 77+ImageHolder;
                        break;
                    case "R":
                        LeftInput = 79+ImageHolder;
                        break;
                    case "S":
                        LeftInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        LeftInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        LeftInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        LeftInput = 87+ImageHolder;
                        break;
                    case "T":
                        LeftInput = 89+ImageHolder;
                        break;
                    case "U":
                        LeftInput = 91+ImageHolder;
                        break;
                    case "V":
                        LeftInput = 93+ImageHolder;
                        break;
                    case "W":
                        UpInput = 95+ImageHolder;
                        break;
                    case "X":
                        LeftInput = 97+ImageHolder;
                        break;
                    case "Y":
                        LeftInput = 99+ImageHolder;
                        break;
                    case "Z":
                        LeftInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        LeftInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        LeftInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        LeftInput = 107+ImageHolder;
                        break;
                }
                break;
            case "DOWN":
                switch (binding)
                {
                    case "0":
                        DownInput = 1 + ImageHolder;
                        break;
                    case "1":
                        DownInput = 3 + ImageHolder;
                        break;
                    case "2":
                        DownInput = 5 + ImageHolder;
                        break;
                    case "3":
                        DownInput = 7 + ImageHolder;
                        break;
                    case "4":
                        DownInput = 9 + ImageHolder;
                        break;
                    case "5":
                        DownInput = 11+ImageHolder;
                        break;
                    case "6":
                        DownInput = 13+ImageHolder;
                        break;
                    case "7":
                        DownInput = 15+ImageHolder;
                        break;
                    case "8":
                        DownInput = 17+ImageHolder;
                        break;
                    case "9":
                        DownInput = 19+ImageHolder;
                        break;
                    case "A":
                        DownInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        DownInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        DownInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        DownInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        DownInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        DownInput = 31+ImageHolder;
                        break;
                    case "B":
                        DownInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        DownInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        DownInput = 37+ImageHolder;
                        break;
                    case "C":
                        DownInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        DownInput = 41+ImageHolder;
                        break;
                    case "D":
                        DownInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        DownInput = 45+ImageHolder;
                        break;
                    case "E":
                        DownInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        DownInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        DownInput = 51+ImageHolder;
                        break;
                    case "F":
                        DownInput = 53+ImageHolder;
                        break;
                    case "G":
                        DownInput = 55+ImageHolder;
                        break;
                    case "H":
                        DownInput = 57+ImageHolder;
                        break;
                    case "I":
                        DownInput = 59+ImageHolder;
                        break;
                    case "J":
                        DownInput = 61+ImageHolder;
                        break;
                    case "K":
                        DownInput = 63+ImageHolder;
                        break;
                    case "L":
                        DownInput = 65+ImageHolder;
                        break;
                    case "M":
                        DownInput = 67+ImageHolder;
                        break;
                    case "N":
                        DownInput = 69+ImageHolder;
                        break;
                    case "O":
                        DownInput = 71+ImageHolder;
                        break;
                    case "P":
                        DownInput = 73+ImageHolder;
                        break;
                    case "Period":
                        DownInput = 75+ImageHolder;
                        break;
                    case "Q":
                        DownInput = 77+ImageHolder;
                        break;
                    case "R":
                        DownInput = 79+ImageHolder;
                        break;
                    case "S":
                        DownInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        DownInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        DownInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        DownInput = 87+ImageHolder;
                        break;
                    case "T":
                        DownInput = 89+ImageHolder;
                        break;
                    case "U":
                        DownInput = 91+ImageHolder;
                        break;
                    case "V":
                        DownInput = 93+ImageHolder;
                        break;
                    case "W":
                        DownInput = 95+ImageHolder;
                        break;
                    case "X":
                        DownInput = 97+ImageHolder;
                        break;
                    case "Y":
                        DownInput = 99+ImageHolder;
                        break;
                    case "Z":
                        DownInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        DownInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        DownInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        DownInput = 107+ImageHolder;
                        break;
                }
                break;
            case "RIGHT":
                switch (binding)
                {
                    case "0":
                        RightInput = 1 + ImageHolder;
                        break;
                    case "1":
                        RightInput = 3 + ImageHolder;
                        break;
                    case "2":
                        RightInput = 5 + ImageHolder;
                        break;
                    case "3":
                        RightInput = 7 + ImageHolder;
                        break;
                    case "4":
                        RightInput = 9 + ImageHolder;
                        break;
                    case "5":
                        RightInput = 11+ImageHolder;
                        break;
                    case "6":
                        RightInput = 13+ImageHolder;
                        break;
                    case "7":
                        RightInput = 15+ImageHolder;
                        break;
                    case "8":
                        RightInput = 17+ImageHolder;
                        break;
                    case "9":
                        RightInput = 19+ImageHolder;
                        break;
                    case "A":
                        RightInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        RightInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        RightInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        RightInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        RightInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        RightInput = 31+ImageHolder;
                        break;
                    case "B":
                        RightInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        RightInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        RightInput = 37+ImageHolder;
                        break;
                    case "C":
                        RightInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        RightInput = 41+ImageHolder;
                        break;
                    case "D":
                        RightInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        RightInput = 45+ImageHolder;
                        break;
                    case "E":
                        RightInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        RightInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        RightInput = 51+ImageHolder;
                        break;
                    case "F":
                        RightInput = 53+ImageHolder;
                        break;
                    case "G":
                        RightInput = 55+ImageHolder;
                        break;
                    case "H":
                        RightInput = 57+ImageHolder;
                        break;
                    case "I":
                        RightInput = 59+ImageHolder;
                        break;
                    case "J":
                        RightInput = 61+ImageHolder;
                        break;
                    case "K":
                        RightInput = 63+ImageHolder;
                        break;
                    case "L":
                        RightInput = 65+ImageHolder;
                        break;
                    case "M":
                        RightInput = 67+ImageHolder;
                        break;
                    case "N":
                        RightInput = 69+ImageHolder;
                        break;
                    case "O":
                        RightInput = 71+ImageHolder;
                        break;
                    case "P":
                        RightInput = 73+ImageHolder;
                        break;
                    case "Period":
                        RightInput = 75+ImageHolder;
                        break;
                    case "Q":
                        RightInput = 77+ImageHolder;
                        break;
                    case "R":
                        RightInput = 79+ImageHolder;
                        break;
                    case "S":
                        RightInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        RightInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        RightInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        RightInput = 87+ImageHolder;
                        break;
                    case "T":
                        RightInput = 89+ImageHolder;
                        break;
                    case "U":
                        RightInput = 91+ImageHolder;
                        break;
                    case "V":
                        RightInput = 93+ImageHolder;
                        break;
                    case "W":
                        RightInput = 95+ImageHolder;
                        break;
                    case "X":
                        RightInput = 97+ImageHolder;
                        break;
                    case "Y":
                        RightInput = 99+ImageHolder;
                        break;
                    case "Z":
                        RightInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        RightInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        RightInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        RightInput = 107+ImageHolder;
                        break;
                }
                break;
            case "PUNCH":
                switch (binding)
                {
                    case "0":
                        PunchInput = 1 + ImageHolder;
                        break;
                    case "1":
                        PunchInput = 3 + ImageHolder;
                        break;
                    case "2":
                        PunchInput = 5 + ImageHolder;
                        break;
                    case "3":
                        PunchInput = 7 + ImageHolder;
                        break;
                    case "4":
                        PunchInput = 9 + ImageHolder;
                        break;
                    case "5":
                        PunchInput = 11+ImageHolder;
                        break;
                    case "6":
                        PunchInput = 13+ImageHolder;
                        break;
                    case "7":
                        PunchInput = 15+ImageHolder;
                        break;
                    case "8":
                        PunchInput = 17+ImageHolder;
                        break;
                    case "9":
                        PunchInput = 19+ImageHolder;
                        break;
                    case "A":
                        PunchInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        PunchInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        PunchInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        PunchInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        PunchInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        PunchInput = 31+ImageHolder;
                        break;
                    case "B":
                        PunchInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        PunchInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        PunchInput = 37+ImageHolder;
                        break;
                    case "C":
                        PunchInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        PunchInput = 41+ImageHolder;
                        break;
                    case "D":
                        PunchInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        PunchInput = 45+ImageHolder;
                        break;
                    case "E":
                        PunchInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        PunchInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        PunchInput = 51+ImageHolder;
                        break;
                    case "F":
                        PunchInput = 53+ImageHolder;
                        break;
                    case "G":
                        PunchInput = 55+ImageHolder;
                        break;
                    case "H":
                        PunchInput = 57+ImageHolder;
                        break;
                    case "I":
                        PunchInput = 59+ImageHolder;
                        break;
                    case "J":
                        PunchInput = 61+ImageHolder;
                        break;
                    case "K":
                        PunchInput = 63+ImageHolder;
                        break;
                    case "L":
                        PunchInput = 65+ImageHolder;
                        break;
                    case "M":
                        PunchInput = 67+ImageHolder;
                        break;
                    case "N":
                        PunchInput = 69+ImageHolder;
                        break;
                    case "O":
                        PunchInput = 71+ImageHolder;
                        break;
                    case "P":
                        PunchInput = 73+ImageHolder;
                        break;
                    case "Period":
                        PunchInput = 75+ImageHolder;
                        break;
                    case "Q":
                        PunchInput = 77+ImageHolder;
                        break;
                    case "R":
                        PunchInput = 79+ImageHolder;
                        break;
                    case "S":
                        PunchInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        PunchInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        PunchInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        PunchInput = 87+ImageHolder;
                        break;
                    case "T":
                        PunchInput = 89+ImageHolder;
                        break;
                    case "U":
                        PunchInput = 91+ImageHolder;
                        break;
                    case "V":
                        PunchInput = 93+ImageHolder;
                        break;
                    case "W":
                        PunchInput = 95+ImageHolder;
                        break;
                    case "X":
                        PunchInput = 97+ImageHolder;
                        break;
                    case "Y":
                        PunchInput = 99+ImageHolder;
                        break;
                    case "Z":
                        PunchInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        PunchInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        PunchInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        PunchInput = 107+ImageHolder;
                        break;
                }
                break;
            case "KICK":
                switch (binding)
                {
                    case "0":
                        KickInput = 1 + ImageHolder;
                        break;
                    case "1":
                        KickInput = 3 + ImageHolder;
                        break;
                    case "2":
                        KickInput = 5 + ImageHolder;
                        break;
                    case "3":
                        KickInput = 7 + ImageHolder;
                        break;
                    case "4":
                        KickInput = 9 + ImageHolder;
                        break;
                    case "5":
                        KickInput = 11+ImageHolder;
                        break;
                    case "6":
                        KickInput = 13+ImageHolder;
                        break;
                    case "7":
                        KickInput = 15+ImageHolder;
                        break;
                    case "8":
                        KickInput = 17+ImageHolder;
                        break;
                    case "9":
                        KickInput = 19+ImageHolder;
                        break;
                    case "A":
                        KickInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        KickInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        KickInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        KickInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        KickInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        KickInput = 31+ImageHolder;
                        break;
                    case "B":
                        KickInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        KickInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        KickInput = 37+ImageHolder;
                        break;
                    case "C":
                        KickInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        KickInput = 41+ImageHolder;
                        break;
                    case "D":
                        KickInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        KickInput = 45+ImageHolder;
                        break;
                    case "E":
                        KickInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        KickInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        KickInput = 51+ImageHolder;
                        break;
                    case "F":
                        KickInput = 53+ImageHolder;
                        break;
                    case "G":
                        KickInput = 55+ImageHolder;
                        break;
                    case "H":
                        KickInput = 57+ImageHolder;
                        break;
                    case "I":
                        KickInput = 59+ImageHolder;
                        break;
                    case "J":
                        KickInput = 61+ImageHolder;
                        break;
                    case "K":
                        KickInput = 63+ImageHolder;
                        break;
                    case "L":
                        KickInput = 65+ImageHolder;
                        break;
                    case "M":
                        KickInput = 67+ImageHolder;
                        break;
                    case "N":
                        KickInput = 69+ImageHolder;
                        break;
                    case "O":
                        KickInput = 71+ImageHolder;
                        break;
                    case "P":
                        KickInput = 73+ImageHolder;
                        break;
                    case "Period":
                        KickInput = 75+ImageHolder;
                        break;
                    case "Q":
                        KickInput = 77+ImageHolder;
                        break;
                    case "R":
                        KickInput = 79+ImageHolder;
                        break;
                    case "S":
                        KickInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        KickInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        KickInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        KickInput = 87+ImageHolder;
                        break;
                    case "T":
                        KickInput = 89+ImageHolder;
                        break;
                    case "U":
                        KickInput = 91+ImageHolder;
                        break;
                    case "V":
                        KickInput = 93+ImageHolder;
                        break;
                    case "W":
                        KickInput = 95+ImageHolder;
                        break;
                    case "X":
                        KickInput = 97+ImageHolder;
                        break;
                    case "Y":
                        KickInput = 99+ImageHolder;
                        break;
                    case "Z":
                        KickInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        KickInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        KickInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        KickInput = 107+ImageHolder;
                        break;
                }
                break;
            case "GRAPPLE":
                switch (binding)
                {
                    case "0":
                        GrappleInput = 1 + ImageHolder;
                        break;
                    case "1":
                        GrappleInput = 3 + ImageHolder;
                        break;
                    case "2":
                        GrappleInput = 5 + ImageHolder;
                        break;
                    case "3":
                        GrappleInput = 7 + ImageHolder;
                        break;
                    case "4":
                        GrappleInput = 9 + ImageHolder;
                        break;
                    case "5":
                        GrappleInput = 11+ImageHolder;
                        break;
                    case "6":
                        GrappleInput = 13+ImageHolder;
                        break;
                    case "7":
                        GrappleInput = 15+ImageHolder;
                        break;
                    case "8":
                        GrappleInput = 17+ImageHolder;
                        break;
                    case "9":
                        GrappleInput = 19+ImageHolder;
                        break;
                    case "A":
                        GrappleInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        GrappleInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        GrappleInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        GrappleInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        GrappleInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        GrappleInput = 31+ImageHolder;
                        break;
                    case "B":
                        GrappleInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        GrappleInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        GrappleInput = 37+ImageHolder;
                        break;
                    case "C":
                        GrappleInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        GrappleInput = 41+ImageHolder;
                        break;
                    case "D":
                        GrappleInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        GrappleInput = 45+ImageHolder;
                        break;
                    case "E":
                        GrappleInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        GrappleInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        GrappleInput = 51+ImageHolder;
                        break;
                    case "F":
                        GrappleInput = 53+ImageHolder;
                        break;
                    case "G":
                        GrappleInput = 55+ImageHolder;
                        break;
                    case "H":
                        GrappleInput = 57+ImageHolder;
                        break;
                    case "I":
                        GrappleInput = 59+ImageHolder;
                        break;
                    case "J":
                        GrappleInput = 61+ImageHolder;
                        break;
                    case "K":
                        GrappleInput = 63+ImageHolder;
                        break;
                    case "L":
                        GrappleInput = 65+ImageHolder;
                        break;
                    case "M":
                        GrappleInput = 67+ImageHolder;
                        break;
                    case "N":
                        GrappleInput = 69+ImageHolder;
                        break;
                    case "O":
                        GrappleInput = 71+ImageHolder;
                        break;
                    case "P":
                        GrappleInput = 73+ImageHolder;
                        break;
                    case "Period":
                        GrappleInput = 75+ImageHolder;
                        break;
                    case "Q":
                        GrappleInput = 77+ImageHolder;
                        break;
                    case "R":
                        GrappleInput = 79+ImageHolder;
                        break;
                    case "S":
                        GrappleInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        GrappleInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        GrappleInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        GrappleInput = 87+ImageHolder;
                        break;
                    case "T":
                        GrappleInput = 89+ImageHolder;
                        break;
                    case "U":
                        GrappleInput = 91+ImageHolder;
                        break;
                    case "V":
                        GrappleInput = 93+ImageHolder;
                        break;
                    case "W":
                        GrappleInput = 95+ImageHolder;
                        break;
                    case "X":
                        GrappleInput = 97+ImageHolder;
                        break;
                    case "Y":
                        GrappleInput = 99+ImageHolder;
                        break;
                    case "Z":
                        GrappleInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        GrappleInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        GrappleInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        GrappleInput = 107+ImageHolder;
                        break;
                }
                break;
            case "INTERACT":
                switch (binding)
                {
                    case "0":
                        InteractInput = 1 + ImageHolder;
                        break;
                    case "1":
                        InteractInput = 3 + ImageHolder;
                        break;
                    case "2":
                        InteractInput = 5 + ImageHolder;
                        break;
                    case "3":
                        InteractInput = 7 + ImageHolder;
                        break;
                    case "4":
                        InteractInput = 9 + ImageHolder;
                        break;
                    case "5":
                        InteractInput = 11+ImageHolder;
                        break;
                    case "6":
                        InteractInput = 13+ImageHolder;
                        break;
                    case "7":
                        InteractInput = 15+ImageHolder;
                        break;
                    case "8":
                        InteractInput = 17+ImageHolder;
                        break;
                    case "9":
                        InteractInput = 19+ImageHolder;
                        break;
                    case "A":
                        InteractInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        InteractInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        InteractInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        InteractInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        InteractInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        InteractInput = 31+ImageHolder;
                        break;
                    case "B":
                        InteractInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        InteractInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        InteractInput = 37+ImageHolder;
                        break;
                    case "C":
                        InteractInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        InteractInput = 41+ImageHolder;
                        break;
                    case "D":
                        InteractInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        InteractInput = 45+ImageHolder;
                        break;
                    case "E":
                        InteractInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        InteractInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        InteractInput = 51+ImageHolder;
                        break;
                    case "F":
                        InteractInput = 53+ImageHolder;
                        break;
                    case "G":
                        InteractInput = 55+ImageHolder;
                        break;
                    case "H":
                        InteractInput = 57+ImageHolder;
                        break;
                    case "I":
                        InteractInput = 59+ImageHolder;
                        break;
                    case "J":
                        InteractInput = 61+ImageHolder;
                        break;
                    case "K":
                        InteractInput = 63+ImageHolder;
                        break;
                    case "L":
                        InteractInput = 65+ImageHolder;
                        break;
                    case "M":
                        InteractInput = 67+ImageHolder;
                        break;
                    case "N":
                        InteractInput = 69+ImageHolder;
                        break;
                    case "O":
                        InteractInput = 71+ImageHolder;
                        break;
                    case "P":
                        InteractInput = 73+ImageHolder;
                        break;
                    case "Period":
                        InteractInput = 75+ImageHolder;
                        break;
                    case "Q":
                        InteractInput = 77+ImageHolder;
                        break;
                    case "R":
                        InteractInput = 79+ImageHolder;
                        break;
                    case "S":
                        InteractInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        InteractInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        InteractInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        InteractInput = 87+ImageHolder;
                        break;
                    case "T":
                        InteractInput = 89+ImageHolder;
                        break;
                    case "U":
                        InteractInput = 91+ImageHolder;
                        break;
                    case "V":
                        InteractInput = 93+ImageHolder;
                        break;
                    case "W":
                        InteractInput = 95+ImageHolder;
                        break;
                    case "X":
                        InteractInput = 97+ImageHolder;
                        break;
                    case "Y":
                        InteractInput = 99+ImageHolder;
                        break;
                    case "Z":
                        InteractInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        InteractInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        InteractInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        InteractInput = 107+ImageHolder;
                        break;
                }
                break;
            case "PAUSE":
                switch (binding)
                {
                    case "0":
                        PauseInput = 1 + ImageHolder;
                        break;
                    case "1":
                        PauseInput = 3 + ImageHolder;
                        break;
                    case "2":
                        PauseInput = 5 + ImageHolder;
                        break;
                    case "3":
                        PauseInput = 7 + ImageHolder;
                        break;
                    case "4":
                        PauseInput = 9 + ImageHolder;
                        break;
                    case "5":
                        PauseInput = 11+ImageHolder;
                        break;
                    case "6":
                        PauseInput = 13+ImageHolder;
                        break;
                    case "7":
                        PauseInput = 15+ImageHolder;
                        break;
                    case "8":
                        PauseInput = 17+ImageHolder;
                        break;
                    case "9":
                        PauseInput = 19+ImageHolder;
                        break;
                    case "A":
                        PauseInput = 21+ImageHolder;
                        break;
                    case "Quote":
                        PauseInput = 23+ImageHolder;
                        break;
                    case "DownArrow":
                        PauseInput = 25+ImageHolder;
                        break;
                    case "LeftArrow":
                        PauseInput = 27+ImageHolder;
                        break;
                    case "RightArrow":
                        PauseInput = 29+ImageHolder;
                        break;
                    case "UpArrow":
                        PauseInput = 31+ImageHolder;
                        break;
                    case "B":
                        PauseInput = 33+ImageHolder;
                        break;
                    case "LeftBracket":
                        PauseInput = 35+ImageHolder;
                        break;
                    case "RightBracket":
                        PauseInput = 37+ImageHolder;
                        break;
                    case "C":
                        PauseInput = 39+ImageHolder;
                        break;
                    case "Comma":
                        PauseInput = 41+ImageHolder;
                        break;
                    case "D":
                        PauseInput = 43+ImageHolder;
                        break;
                    case "Minus":
                        PauseInput = 45+ImageHolder;
                        break;
                    case "E":
                        PauseInput = 47+ImageHolder;
                        break;
                    case "Equals":
                        PauseInput = 49+ImageHolder;
                        break;
                    case "Escape":
                        PauseInput = 51+ImageHolder;
                        break;
                    case "F":
                        PauseInput = 53+ImageHolder;
                        break;
                    case "G":
                        PauseInput = 55+ImageHolder;
                        break;
                    case "H":
                        PauseInput = 57+ImageHolder;
                        break;
                    case "I":
                        PauseInput = 59+ImageHolder;
                        break;
                    case "J":
                        PauseInput = 61+ImageHolder;
                        break;
                    case "K":
                        PauseInput = 63+ImageHolder;
                        break;
                    case "L":
                        PauseInput = 65+ImageHolder;
                        break;
                    case "M":
                        PauseInput = 67+ImageHolder;
                        break;
                    case "N":
                        PauseInput = 69+ImageHolder;
                        break;
                    case "O":
                        PauseInput = 71+ImageHolder;
                        break;
                    case "P":
                        PauseInput = 73+ImageHolder;
                        break;
                    case "Period":
                        PauseInput = 75+ImageHolder;
                        break;
                    case "Q":
                        PauseInput = 77+ImageHolder;
                        break;
                    case "R":
                        PauseInput = 79+ImageHolder;
                        break;
                    case "S":
                        PauseInput = 81+ImageHolder;
                        break;
                    case "Semicolon":
                        PauseInput = 83+ImageHolder;
                        break;
                    case "Slash":
                        PauseInput = 85+ImageHolder;
                        break;
                    case "Backslash":
                        PauseInput = 87+ImageHolder;
                        break;
                    case "T":
                        PauseInput = 89+ImageHolder;
                        break;
                    case "U":
                        PauseInput = 91+ImageHolder;
                        break;
                    case "V":
                        PauseInput = 93+ImageHolder;
                        break;
                    case "W":
                        PauseInput = 95+ImageHolder;
                        break;
                    case "X":
                        PauseInput = 97+ImageHolder;
                        break;
                    case "Y":
                        PauseInput = 99+ImageHolder;
                        break;
                    case "Z":
                        PauseInput = 101+ImageHolder;
                        break;
                    case "LeftClick":
                        PauseInput = 103+ImageHolder;
                        break;
                    case "MiddleClick":
                        PauseInput = 105+ImageHolder;
                        break;
                    case "RightClick":
                        PauseInput = 107+ImageHolder;
                        break;
                }
                break;
        }
        CanChange = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ImageDelay > 0)
        {
            ImageDelay -= Time.deltaTime;
        }
        UP = KeyboardKeyBinds.ElementAt(UpInput);
        LEFT = KeyboardKeyBinds.ElementAt(LeftInput);
        DOWN = KeyboardKeyBinds.ElementAt(DownInput);
        RIGHT = KeyboardKeyBinds.ElementAt(RightInput);
        PUNCH = KeyboardKeyBinds.ElementAt(PunchInput);
        KICK = KeyboardKeyBinds.ElementAt(KickInput);
        GRAPPLE = KeyboardKeyBinds.ElementAt(GrappleInput);
        INTERACT = KeyboardKeyBinds.ElementAt(InteractInput);
        PAUSE = KeyboardKeyBinds.ElementAt(PauseInput);
        upi.GetComponent<SpriteRenderer>().sprite = UP;
        lefti.GetComponent<SpriteRenderer>().sprite = LEFT;
        downi.GetComponent<SpriteRenderer>().sprite = DOWN;
        righti.GetComponent<SpriteRenderer>().sprite = RIGHT;
        punchi.GetComponent<SpriteRenderer>().sprite = PUNCH;
        kicki.GetComponent<SpriteRenderer>().sprite = KICK;
        grapplei.GetComponent<SpriteRenderer>().sprite = GRAPPLE;
        interacti.GetComponent<SpriteRenderer>().sprite = INTERACT;
        pausei.GetComponent<SpriteRenderer>().sprite = PAUSE;
        if (ImageDelay <= 0&&CanChange)
        {
            if (ImageChange)
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
