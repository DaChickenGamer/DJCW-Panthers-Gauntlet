using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int redTeamScore = 0;
    public static int blueTeamScore = 0;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI player2Score;

    public void Start()
    {
        playerScore.color = Color.red;
        player2Score.color = Color.blue;
    }
    void Update()
    {
        playerScore.text = redTeamScore.ToString();
        player2Score.text = blueTeamScore.ToString();
        
    }
}
