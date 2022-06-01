using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    // Overall WIP Progress Bar
    public int MoneyBar;

    //Each question's score by player
    public int QuestionOneScore;
    public int QuestionTwoScore;

    public int FireHireProgressBar;
    public int level;
    public float[] PlayerPosition;

    public PlayerData (PlayerController player) {

        MoneyBar = player.MoneyBar;
        FireHireProgressBar = player.FireHireProgressBar;
        level = player.level;
        QuestionOneScore = player.QuestionOneScore;
        QuestionTwoScore = player.QuestionTwoScore;

        PlayerPosition = new float[3];
        PlayerPosition[0] = player.transform.position.x;
        PlayerPosition[1] = player.transform.position.y;
        PlayerPosition[2] = player.transform.position.z;
        

    }

}
