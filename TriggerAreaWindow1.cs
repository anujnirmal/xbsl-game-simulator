using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class TriggerAreaWindow1 : MonoBehaviour
{
    
    
    public VideoPlayer QuestionVideoPlay;

    public GameObject QuestionVideoPlayObject;
    //Option Texts
    [TextArea]
    public string QuestionOneText;
    [TextArea]
    public string OptionOneText;
    [TextArea]
    public string OptionTwoText;
    [TextArea]
    public string OptionThreeText;
    [TextArea]
    public string OptionFourText;
    //Option Texts Ends here

    // Reasoning for all the answer
    [TextArea]
    public string ReasonForBestAnswer;
    [TextArea]
    public string ReasonForGoodAnswer;
    [TextArea]
    public string ReasonForAverageAnswer;
    [TextArea]
    public string ReasonForWorstAnswer;

    public TMP_Text ReasoningText;
    // Reason for all the answer ends here

    // Getting the entire Assesment Null to set it to Visible
    public GameObject AssesmentOne;

    public GameObject QuestionBoxHolder;
    public GameObject ReasoningBoxHolder;
    // Ui Elements to hide/Unhide Ends here

    // Getting the toggle group for the answer
    public ToggleGroup toggleGroup;
    // Option one for the question

    // Correct Answer text = OptionOne, OptionTwo, OptionThree, OptionFour
    public string QuestionOneBestAnswer = "OptionTwo"; 
    public string QuestionOneGoodAnswer = "OptionThree";
    public string QuestionOneAverageAnswer = "OptionFour";
    public string QuestionOneWorstAnswer = "OptionOne";

    public Slider ReasoningSectionSlider;

    
    public TMP_Text QuestionOneTextBox;
    public TMP_Text Option1Text;
    // Option Two for the question
    public TMP_Text Option2Text;
    // Option Three for the question
    public TMP_Text Option3Text;
    // Option Four for the question    
    public TMP_Text Option4Text;

    // Selecting the arrows to show

    public GameObject BestArrow;
    public GameObject GoodArrow;
    public GameObject AverageArrow;
    public GameObject WorstArrow;

    // Arrow selection ends here

    public GameObject AssessmentManager;
    public PlayerController playerOne;
    public GameObject JoyStickMove;
    public GameObject JoyStickLook;
    public GameObject MainMenu;
    public GameObject MoneyBar;
    public GameObject ObjectiveButton;
    public GameObject FireHireButton;
    public GameObject WIPButton;
    
    private bool triggerAreaOne = false;
    // Start is called before the first frame update
    void Start()
    {

        if( toggleGroup == null ) toggleGroup = GetComponent<ToggleGroup>();
        //toggleGroup = GetComponent<ToggleGroup>();

    }

    // Update is called once per frame
    void Update()
    {

        // if(triggerAreaOne == true) {
        //     Debug.Log("Called");
        //     playerOne.transform.position = new Vector3(6.3f,-0.1f,5.242f);
        // }

    }

    private void OnTriggerEnter(Collider other) {
        
        
        QuestionVideoPlay.Play();
        JoyStickMove.SetActive(false);
        JoyStickLook.SetActive(false);
        MainMenu.SetActive(false);
        MoneyBar.SetActive(false);
        ObjectiveButton.SetActive(false);
        FireHireButton.SetActive(false);
        WIPButton.SetActive(false);

        // Playing the question one video before the assesment
        // Checking to see when the video reaches the end
        QuestionVideoPlay.loopPointReached += CheckOverVideo;

        
        
    }

    // Once the video reaches the end this function is caleld
    private void CheckOverVideo(VideoPlayer vp){

        // Turning off the Question Video Player Object
        QuestionVideoPlayObject.SetActive(false);
        JoyStickMove.SetActive(true);
        JoyStickLook.SetActive(true);
        MainMenu.SetActive(false);
        MoneyBar.SetActive(false);
        ObjectiveButton.SetActive(true);
        FireHireButton.SetActive(false);
        WIPButton.SetActive(true);
        Debug.Log("Video is Over");
        // Starting the asesment
        ShowTheAssesment();

    }

    private void ShowTheAssesment(){

        // playerOne.playerPosition = new Vector3(6.3f,-0.1f,5.242f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Debug.Log(other);
        // Debug.Log(playerOne.transform.position);
        // triggerAreaOne = true;
        QuestionOneTextBox.text = QuestionOneText;
        Option1Text.text = OptionOneText;
        Option2Text.text = OptionTwoText;
        Option3Text.text = OptionThreeText;
        Option4Text.text = OptionFourText;
        AssesmentOne.SetActive(true);
        QuestionBoxHolder.SetActive(true);
        JoyStickLook.SetActive(false);
        JoyStickMove.SetActive(false);
        MainMenu.SetActive(false);
        // Debug.Log(playerOne.transform.position);

    }

    public void SubmitAssessmentOne(){


     

        //Debug.Log(OptionOne.isOn);

        //Debug.Log(toggleGroup.ActiveToggles());


        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        //Debug.Log(toggle.name + " _ "  +  toggle.GetComponentInChildren<Text>().text);
        
        // Cash Money for each answer
        int ScoreForBestAnswer = 100000;
        int ScoreForGoodAnswer = 60000;
        int ScoreForAverageAnswer = 30000;
        int ScoreForWorstAnswer = 0;

        // Checking if the answer is correct
        if (toggle.name == QuestionOneBestAnswer) {

            // if answer is correct than we increment the following counter in PlayerController Script
            // "MoneyBar" according the point system
            playerOne.MoneyBar += ScoreForBestAnswer; 
            playerOne.QuestionOneScore += ScoreForBestAnswer;
            ReasoningSectionSlider.value = 100;
            BestArrow.SetActive(true);
            ReasoningText.text = ReasonForBestAnswer;
            saveGameProgress();
            ReasoningSectionOpener();
        
        } else if (toggle.name == QuestionOneGoodAnswer) {
        
            playerOne.MoneyBar += ScoreForGoodAnswer; 
            playerOne.QuestionOneScore += ScoreForGoodAnswer;
            ReasoningSectionSlider.value = 60;
            GoodArrow.SetActive(true);
            ReasoningText.text = ReasonForGoodAnswer;
            saveGameProgress();
            ReasoningSectionOpener();
        
        } else if (toggle.name == QuestionOneAverageAnswer){

            playerOne.MoneyBar += ScoreForAverageAnswer;
            playerOne.QuestionOneScore += ScoreForAverageAnswer;
            ReasoningSectionSlider.value = 30;
            AverageArrow.SetActive(true);
            ReasoningText.text = ReasonForAverageAnswer;
            saveGameProgress();
            ReasoningSectionOpener();

        } else if (toggle.name ==  QuestionOneWorstAnswer) {

            playerOne.MoneyBar += ScoreForWorstAnswer;
            playerOne.QuestionOneScore += ScoreForWorstAnswer; 
            ReasoningSectionSlider.value = 0;
            WorstArrow.SetActive(true);
            ReasoningText.text = ReasonForWorstAnswer;
            saveGameProgress();
            ReasoningSectionOpener();

        } else {

            Debug.Log("Unknow error occured, Toggle.Name Current Value" + toggle.name);
            ReasoningSectionOpener();

        }
          
        

    }

    public void NextSceneButton(){
        
        SceneManager.LoadScene("Level2");
    
    }

    private void ReasoningSectionOpener(){

        // Disabling the question & option section
        QuestionBoxHolder.SetActive(false);
        // Enabling the Reasoning Box
        ReasoningBoxHolder.SetActive(true);

    }

    private void DisableArrowReasoning(){
        BestArrow.SetActive(false);
        GoodArrow.SetActive(false);
        AverageArrow.SetActive(false);
        WorstArrow.SetActive(false);
    }

    private void saveGameProgress(){

        // Incrementing the level by one
        playerOne.level += 1;
        // Saving the player
        playerOne.SavePlayer();
    
    }


    

}
