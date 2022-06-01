using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{

    // Typing Speed
    private float typeWriterSpeed = 50f;

    // Selecting the Next Button
    public GameObject NextButton;
    // Text content of the Next Button
    public TMP_Text NextButtonText;

    public void Run(string textToType, TMP_Text textLabel, int IndexText){
        

        if ( (IndexText + 1) == 8 ) {

            NextButtonText.text = "Done";
        
        } else {
        
            NextButtonText.text = "Next >>";
        
        }

        // Setting the text box text to null before starting
        textLabel.text = "";
        // Setting the next button to false
        NextButton.SetActive(false);

        // Typing starts
        StartCoroutine(TypeText(textToType, textLabel, IndexText));

    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel, int IndexText){

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length) {

            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);


            yield return null;

        } 

        textLabel.text = textToType;

        // Sets the next button to active
        NextButton.SetActive(true);

    }

}
