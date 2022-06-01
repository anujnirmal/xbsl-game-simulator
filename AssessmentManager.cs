using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentManager : MonoBehaviour
{
    

    public bool isQuestion1Done = true;
    public bool isQuestion2Done = true;

    public int[] optionPoints;

    // Setting the header for the Inspector
    [Header("Assessments")]

    // Question 1 Start
    [Header("First Assesment")]
    // Question
    [TextArea] 
    public string question1;
    // Array for all the question
    [TextArea]
    public string[] option1;
    public int bestAnswer1;
    public int okAnswer1;
    public int badAnswer1;
    // Question 1 End

    // Question 2 Start
    [Header("Second Assesment")]
    // Question
    [TextArea] 
    public string question2;
    // Array for all the question
    [TextArea]
    public string[] option2;
    public int bestAnswer2;
    public int okAnswer2;
    public int badAnswer2;
    // Question 1 End


}
