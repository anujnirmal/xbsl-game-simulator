using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class GuideManager : MonoBehaviour
{

    public VideoPlayer OrientationVideo;
    public GameObject BackGroundForVideo;
    public GameObject OrientationVideoPlayerObject;
    public TypeWriterEffect typeWriterEffect;
    public Animator BotAnimation;
    public GameObject JoyStickLook;
    public GameObject JoyStickMove;
    public GameObject ProgressMoneyBar;
    public GameObject ProgressHireFire;
    public GameObject MenuButton;
    public GameObject WIPButton;
    public GameObject ObjectiveButton;
    public GameObject ZeroBot;
    public GameObject NextButton;
    

    public GameObject ZeroBotGuideBox;
    public TMP_Text ZeroDialoguesBoxText;

    [TextArea]
    public string[] DialogueForBotGuideScene;

    int TimeLeftToStartGuide = 2; 

    private int botUp = 1; //if 1 that means the bot is up if any more then stop

    private int GuideNumberCompleted; // Number of elements shown on screen, start 1


    // Start is called before the first frame update

    private void Awake() {
        
        //BackGroundForVideo.SetActive(false);
        DisableViewObjects();
        OrientationVideo.Play();
        
        // OrientationVideo.frameReady += PlayTheVideo;
        Debug.Log("Total Frames " + OrientationVideo.frameCount);
        OrientationVideo.loopPointReached += CheckOverVideo;

    }

    private void PlayTheVideo(){

        Debug.Log("Ready to play");

    }

    private void CheckOverVideo(VideoPlayer vp){

        
        Debug.Log("Video is Over");
        countDownTimer();
        // Starting the main guide once the video is over
        StartGuide();

    }

    private void Start() {

        // countDownTimer();
        // Starting the main guide once the video is over
        //StartGuide();

    }


    // Update is called once per frame
    void Update()
    {

        // Checks if the animation of the Bot is completed
        if (BotAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !BotAnimation.IsInTransition(0)){

            if(botUp == 1) {

                ZeroBotIntro(0);
                Debug.Log("Animation Complete");
                botUp += 1;

            } 

        }

        Debug.Log(OrientationVideo.frame);

        if (OrientationVideo.frame > 1) {

            BackGroundForVideo.SetActive(false);            

        }

    }

    void countDownTimer() {  

        if (TimeLeftToStartGuide > 0) { 

            TimeSpan spanTime = TimeSpan.FromSeconds(TimeLeftToStartGuide);  
            Debug.Log(spanTime.Seconds);  
            TimeLeftToStartGuide--;  
            Invoke("countDownTimer", 1.0f);  

        } else {  

            Debug.Log("2 Seconds Up");
            ZeroBot.SetActive(true); 
            BotAnimation.SetBool("BotEntry", true);
            
            
        }  
    
    }  
    
    public void StartGuide() {

        OrientationVideoPlayerObject.SetActive(false);

        // TimeLeftToStartGuide -= Time.deltaTime;

        ZeroDialoguesBoxText.text = DialogueForBotGuideScene[0];

    }

    private void DisableViewObjects(){

        MenuButton.SetActive(false);
        JoyStickLook.SetActive(false);
        JoyStickMove.SetActive(false);
        ProgressMoneyBar.SetActive(false);
        ProgressHireFire.SetActive(false);
        WIPButton.SetActive(false);
        ObjectiveButton.SetActive(false);
        ZeroBot.SetActive(false);
        ZeroBotGuideBox.SetActive(false);
        NextButton.SetActive(false);

    }

    
    private void ZeroBotIntro(int TextIndex){

        // Updating the variable to denote that this element is completed
        GuideNumberCompleted += 1;
        Debug.Log("Completed The Animation");
        ZeroBotGuideBox.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

    public void NextButtonClick(){

        //adding 1 everytime the button gets clicked
        GuideNumberCompleted += 1;

        if (GuideNumberCompleted == 9) {

            ZeroBotGuideBox.SetActive(false);
            BotAnimation.SetBool("BotEntry", false);


        }



        switch (GuideNumberCompleted)
        {   
            case 1:
                ZeroBotIntro(0);
                break;
            case 2:
                MoneyBarIntro(1);
                break;
            case 3:
                HireFireBarIntro(2);
                break;
            case 4: 
                MenuButtonIntro(3);
                break;
            case 5:
                WIPButtonIntro(4);
                break;
            case 6:
                ObjectiveButtonIntro(5);
                break;
            case 7:
                JoyStickLookIntro(6);
                break;
            case 8:
                JoyStickMoveIntro(7);
                break;
            default:
                Debug.Log("None found" + GuideNumberCompleted);
                break;
        }

    }

    // 2nd Element on the canvas
    private void MoneyBarIntro(int TextIndex){

        ProgressMoneyBar.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

    // 3rd Element on the canvas
    private void HireFireBarIntro(int TextIndex){

        ProgressHireFire.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }


    // 4th Element on the canvas
    private void MenuButtonIntro(int TextIndex){

        MenuButton.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

    // 5th Element on the canvas
    private void WIPButtonIntro(int TextIndex){

        WIPButton.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

    // 6th Element on the canvas
    private void ObjectiveButtonIntro(int TextIndex){

        ObjectiveButton.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

    // 7th Element on the canvas
    private void JoyStickLookIntro(int TextIndex){

        JoyStickLook.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

    // 8th Element on the canvas
    private void JoyStickMoveIntro(int TextIndex){

        JoyStickMove.SetActive(true);
        typeWriterEffect.Run(DialogueForBotGuideScene[TextIndex], ZeroDialoguesBoxText, TextIndex);

    }

}

