using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuthUIManager : MonoBehaviour
{
 
    public static AuthUIManager instance;

    [Header("References")]
    [SerializeField]
    private GameObject checkingForAccountUI;
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject registerUI;
    [SerializeField]
    private GameObject verifyEmailUI;
    [SerializeField]
    private TMP_Text verifyEmailText;


    private void Awake() {
        
        if (instance == null) {

            instance = this;

        } else if(instance != this) {

            Destroy(gameObject);

        }

    }

    private void ClearUI() {

        // Hiding the Login and Register Screen
        // By Disabling it
        FirebaseManager.instance.ClearOutputs();
        loginUI.SetActive(false);
        verifyEmailUI.SetActive(false);
        registerUI.SetActive(false);
        checkingForAccountUI.SetActive(false);

    }

    public void LoginScreen() {
        
        // Calling the ClearUI to set any screen already present to disable
        ClearUI();
        // Setting Login Screen to Active/Visible
        loginUI.SetActive(true);

    }

    public void RegisterScreen(){

        // Calling the ClearUI to set any screen already present to disable
        ClearUI();
        // Setting Register Screen to Active/Visible
        registerUI.SetActive(true);

    }

    // public void AwaitVerification(bool _emailSent, string _email, string _output){

    //     ClearUI();
    //     verifyEmailUI.SetActive(true);
    //     if(_emailSent) {

    //         verifyEmailText.text = $"Sent Email!\n Please Verify {_email}";
        
    //     } else {

    //         verifyEmailText.text = $"Email Not Sent: {_output}]\n Please Verify {_email}";

    //     }

    // }

}
