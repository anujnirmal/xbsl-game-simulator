using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WipReportManager : MonoBehaviour
{
    // Selecting the required components using unity Inspector

    // Start is called before the first frame update
    public Slider[] WipReportProgressBarSliders;
    
    //Data for the WIP bars from the main player script
    public PlayerController DataFromPlayerController;
    // Selecting Ends Here

    // Private variables to store the final percentage for the bars
    private float StorytellingScore;
    private float CreativeProblemSolvingScore;


    // Update is called once per frame
    void Update()
    {

        // Taking the score from the player script(eg. "75000")
        // Dividing the money by 1,00,000
        // Multiplying by 100 to get the percentage for the slider
        StorytellingScore = DataFromPlayerController.QuestionOneScore / 1000;         
        CreativeProblemSolvingScore = DataFromPlayerController.QuestionTwoScore / 1000;

        // Setting the Storytelling Bar Slider
        WipReportProgressBarSliders[0].value = StorytellingScore;

        // Setting the Creative Problem Solving
        WipReportProgressBarSliders[2].value = CreativeProblemSolvingScore;    
        
    }
}
