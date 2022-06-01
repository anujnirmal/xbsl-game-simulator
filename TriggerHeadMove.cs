using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TriggerHeadMove : MonoBehaviour
{
    public GameObject AnimationObject;
    public MultiAimConstraint mutliaimConstraint;

    private float weightNumber = 0;
    private bool entered = false;
    private bool exited = false;
    
    private void OnTriggerEnter(Collider other) {
       
        // Setting the weight number to 0
        weightNumber = 0;
        entered = true;
        exited = false;
        //mutliaimConstraint.weight = 1;
        // AnimationObject.SetActive(true);
        Debug.Log("Entered");
        
       // StartCoroutine(UpdateWait(frames));

   
    }

    private void OnTriggerExit(Collider other) {
        
        //Setting 
        weightNumber = 1;
        entered = false;
        exited = true;
        //mutliaimConstraint.weight = 0;
        //AnimationObject.SetActive(false);
        Debug.Log("Exited");

    }

    private void Update() {


        if (entered == true) {

            if (weightNumber < 1) {

                mutliaimConstraint.weight = weightNumber;
                weightNumber += 0.10f;

            }        

        }

        if (exited == true) {

            if (weightNumber > 0) {

                mutliaimConstraint.weight = weightNumber;
                weightNumber -= 0.10f;

            }

        }

    }

   

}
