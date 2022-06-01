using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class AssessmentAnalyzer : MonoBehaviour
{

    ToggleGroup toggleGroup;
   // public GameObject playerOne;
    public TMP_Text QuestionTitle;
    public GameObject Option1Text;
    public GameObject Option2Text;
    public GameObject Option3Text;
    public AssessmentManager AssessmentManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        
        toggleGroup = GetComponent<ToggleGroup>();
      

        //Debug.Log(AssessmentManagerObject.isQuestion1Done);

        // if( AssessmentManagerObject.isQuestion2Done == true) {
        //     Debug.Log(QuestionTitle.text);
        // } else {
        //     Debug.Log(false);
        // }


    }

    
    public void Submit(){

        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + " _ "  +  toggle.GetComponentInChildren<Text>().text);    
        SceneManager.LoadScene("Level2");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
       

    }

}
