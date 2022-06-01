using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public UIVirtualButton submitButton;

    // Overall Assesment score
    // Best Answer = 10 Points
    // Good Answer = 6 Points
    // Average Answer = 3 Points
    // Worst Answer = 0 Points
    public int MoneyBar = 0;

    // Each Question's Asnwer Scored by user
    public int QuestionOneScore = 0;
    public int QuestionTwoScore = 0;
    public int FireHireProgressBar = 0;

    // Wip Progress Bar Object Assets
    //public Slider MoneyBarObject;
    public TMP_Text MoneyBarText;
    // Wip Progress Bar Object Ends Here

    public int level = 1;
    public float[] PlayerPosition;

    public void SavePlayer(){

        SaveSystem.SavePlayer(this);
    
    }

    public void LoadPlayer(){

        PlayerData data = SaveSystem.LoadPlayer();

        MoneyBar = data.MoneyBar;
        // FireHireProgressBar = data.MoneyBar;
        level = data.level;
        QuestionOneScore = data.QuestionOneScore;
        QuestionTwoScore = data.QuestionTwoScore;

        // Vector3 position;
        // position.x = data.PlayerPosition[0];
        // position.y = data.PlayerPosition[1];
        // position.z = data.PlayerPosition[2];


    }

    private void Start() {

        LoadPlayer(); 

    }
    private void Update() {

        // Updating the WIP Progress Bar
        //MoneyBarObject.value = MoneyBar;
        // Updating the percentage number in the WIP Progress Bar
        MoneyBarText.text = MoneyBar.ToString();
      

    }

   
}
