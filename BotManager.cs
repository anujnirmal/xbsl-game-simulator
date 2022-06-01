using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotManager : MonoBehaviour
{

    public TypeWriterEffect typeWriterEffect;
    [TextArea]
    public string level2Objective;
    public GameObject ZeroDialogueBox;
    public TMP_Text ZeroDialoguesBoxText;
    

    // Bot Up count, if 1 then only bot will be shown
    // Basically this is created to stop the looping
    private int botUp = 1;
    public Animator BotAnimation;
    private void Start(){

        BotAnimation.SetBool("BotEntry", true);        

    }

    private void Update() {
        
          if (BotAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !BotAnimation.IsInTransition(0)){

            if(botUp == 1) {

                RunBotDialgue();
                Debug.Log("Animation Complete");
                botUp += 1;

            } 

        }

    }

    private void RunBotDialgue(){

        ZeroDialogueBox.SetActive(true);
        // Passing the text in this function to type it out
        typeWriterEffect.Run(level2Objective, ZeroDialoguesBoxText, 0);

    }

    public void MoveToTheObjectiveLevel2(){

        // Sending the bot Image back to the original place
        BotAnimation.SetBool("BotEntry", false);       
        ZeroDialogueBox.SetActive(false);


    }

}
