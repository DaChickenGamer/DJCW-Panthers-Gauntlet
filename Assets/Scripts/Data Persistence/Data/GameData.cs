using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    /*
        Variables To Add:

        Have all types of data be sent to us

        Give a warning message when collecting the data have a option to opt out from sending the data to us

        Explain it is only things like kicking and punching and easter eggs found
    
        Save a variable for the data sending opt in

        Base for achievement system below

        More Of Fun Data:
            Times KO
            Grapples
            Opponent Beat Time
            Game Beat Time
            How many times you enter the game
            Easter Eggs Found
            Challenges Beat
            Water Drunk
            Items Collected
            Closet Opened
            Codes Entered
            Current Save Point
            Current Enemy
            Distance Walked

        Actual Data:
            Wins
            Losses
            Times KO
            Punches
            Kicks
            Grapples
            Best Opponent Times
            Best Beat Time
            Punching Bag Punches
            Total Playtime
    */
    public int punchCount; // This is a placeholder for the whole system and a test

    // The values defined in this constrcture will be the default values
    // The game starts with when ther's no data to load
    public GameData()
    {
        this.punchCount = 0;
    }
}
