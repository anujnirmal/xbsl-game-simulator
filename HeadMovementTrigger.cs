using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations.Rigging;

public class HeadMovementTrigger : MonoBehaviour
{
    // public MultiAimInverseConstraint rigBodyContraint;
    // public MultiAimInverseConstraintJob rigBodyAnimationJob;
    public GameObject headMoveMentObject; 
  
    // Start is called before the first frame update
    void Start()
    {

        //headMoveMentObject = gameObject.GetComponent<MultiAimContraint>();
        Debug.Log("Here");
        Component[] headMoveMentObject = gameObject.GetComponents(typeof(Component));
        
        foreach(Component component in headMoveMentObject) {

            Debug.Log(component.ToString());
        
        }

        //  foreach(var component in headMoveMentObject.GetComponents(typeof(Component)))
        // {
        //     //text += component.GetType().ToString() + " ";

        //     Debug.Log(component.GetType());
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        // rigBodyContraint.DestroyJob(rigBodyAnimationJob);
        // Debug.Log("Entered");


    }

    private void OnTriggerExit(Collider other) {

        Debug.Log("Exited");

    }
}
