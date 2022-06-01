using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class FirebaseManager : MonoBehaviour
{
  
    public static FirebaseManager instance;

    [Header("Firebase")]
    public FirebaseAuth auth;
    public FirebaseUser user;
    [Space(5f)]

    [Header("Login References")]
    [SerializeField]
    private TMP_InputField loginEmail;
    [SerializeField]
    private TMP_InputField loginPassword;
    [SerializeField]
    private TMP_Text loginOutputText;
    [Space(5f)]

    [Header("Register References")]
    [SerializeField]
    private TMP_InputField registerUsername;
    [SerializeField]
    private TMP_InputField registerEmail;
    [SerializeField]
    private TMP_InputField registerPassword;
    [SerializeField]
    private TMP_InputField registerConfirmPassword;
    [SerializeField]
    private TMP_Text registerOutputText;
    public LoadingSceneManager loadSceneManager;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);

        if (instance == null) {

            instance = this;

        } else if(instance != this) {

            Destroy(instance.gameObject);
            instance = this;
        
        }

      
        
        // FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(checkDependancyTask => {

        //     // Checking if all the dependency for firebase is available
        //     // Storying the result in dependencyStatus
        //     var dependencyStatus = checkDependancyTask.Result;

        //     if(dependencyStatus == DependencyStatus.Available)
        //     {

        //         // If all the dependencys are met, initialize Firebase
        //         InitializeFirebase();
            
        //     }else {

        //         // If all the dependencys are not met, console the error
        //         Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");

        //     }


        // });

    }

    private void Start() {
        
        StartCoroutine(CheckAndFixDependancies());
       
    }

    // public void AutoLoginCustomButton(){

    //     StartCoroutine(CheckAndFixDependancies());

    // }

    private IEnumerator CheckAndFixDependancies() {

        var checkAndFixDependanciesTask = FirebaseApp.CheckAndFixDependenciesAsync();
        
        yield return new WaitUntil(predicate: () => checkAndFixDependanciesTask.IsCompleted);

        var dependancyResult = checkAndFixDependanciesTask.Result;

        if(dependancyResult == DependencyStatus.Available) {

            InitializeFirebase();
        
        } else {

            Debug.LogError($"Could not resolve all Firebase dependancies: {dependancyResult}");

        }

    }

    private void InitializeFirebase() {
        Debug.Log("From Initialize Firebase");
        auth = FirebaseAuth.DefaultInstance;
        StartCoroutine(CheckAutoLogin());
        //AutoLogin();
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);

    }

    private IEnumerator CheckAutoLogin() {
        Debug.Log("From Check Auto Login ....");
        //yield return new WaitForEndOfFrame();

        if(user != null) {

            Debug.Log("User is " + user);
            var reloadUserTask = user.ReloadAsync();

            yield return new WaitUntil(predicate: () => reloadUserTask.IsCompleted);

            AutoLogin();

        } else {

            AuthUIManager.instance.LoginScreen();

        }

    }

    private void AutoLogin(){

        Debug.Log("Calling from Auto Login");

        if (user != null) {

            //GameManager.instance.ChangeScene(1);
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //StartCoroutine(SendVerificationEmail()); 

        } else {

            AuthUIManager.instance.LoginScreen();

        }

    }

    public void UserSignOut(){

        //Signing Out
        auth.SignOut();
        //GameManager.instance.ChangeScene("auth");
        loadSceneManager.LoadLevel("auth");

    }




    private void AuthStateChanged(object sender, System.EventArgs eventArgs) {

        if(auth.CurrentUser != user) {

            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if(!signedIn && user != null) {

                Debug.Log("Signed Out");
            
            }

            user = auth.CurrentUser;

            if (signedIn) {

                Debug.Log($"Signed In: {user.DisplayName}");

                Debug.Log(SceneManager.GetActiveScene().buildIndex);

                if (SceneManager.GetActiveScene().buildIndex == 0) {
                        
                    SceneManager.LoadScene("Lobby");
                } 
                //GameManager.instance.ChangeScene(2);

            }

        }

    }

    public void ClearOutputs(){

        loginOutputText.text = "";
        registerOutputText.text = "";

    }

    public void LoginButton() {

        StartCoroutine(LoginLogic(loginEmail.text, loginPassword.text));

    }

    public void RegisterButton() {

        StartCoroutine(RegisterLogic(registerUsername.text, registerEmail.text, registerPassword.text, registerConfirmPassword.text));

    }


    private IEnumerator LoginLogic(string _email, string _password) {
        
        Debug.Log("Login Called");

        Credential credential = EmailAuthProvider.GetCredential(_email, _password);
        var loginTask = auth.SignInWithCredentialAsync(credential);

        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null){

            FirebaseException firebaseException = (FirebaseException)loginTask.Exception.GetBaseException();
            AuthError error = (AuthError)firebaseException.ErrorCode;
            string output = "Unknown Error, Please Try Again";

            switch (error){

                case AuthError.MissingEmail:
                    output = "Please Enter Your Email";
                    break;
                case AuthError.MissingPassword:
                    output = "Please Enter Your Password";
                    break;
                case AuthError.InvalidEmail:
                    output = "Invalid Email";
                    break;
                case AuthError.WrongPassword:
                    output = "Incorrect Password";
                    break;
                case AuthError.UserNotFound:
                    output = "Account Does Not Exist";
                    break;
            }

            // Seting the loginOutputText to the error message
            loginOutputText.text = output;

        } else {

                // TODO: Send Verification Email
                //GameManager.instance.ChangeScene("Lobby");
                loadSceneManager.LoadLevel("Lobby");
        }

    }

    private IEnumerator RegisterLogic(string _username, string _email, string _password, string _confirmPassword){

        if(_username == ""){

            registerOutputText.text = "Please Enter A Username";
        
        } else if (_password != _confirmPassword){

            registerOutputText.text = "Passwords Do Not Match!";

        } else {

            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
        
            yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

            if(registerTask.Exception != null) {
                Debug.Log("Inside Exception");
                FirebaseException firebaseException = (FirebaseException)registerTask.Exception.GetBaseException();
                AuthError error = (AuthError)firebaseException.ErrorCode;
                string output = "Unknown Error, Please Try Again";

                switch (error){

                    case AuthError.InvalidEmail:
                        output = "Invalid Email";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        output = "Email Already In Use";
                        break;
                    case AuthError.WeakPassword:
                        output = "Weak Password";
                        break;
                    case AuthError.MissingEmail:
                        output = "Please Enter Your Email";
                        break;
                    case AuthError.MissingPassword:
                        output = "Please Enter Your Password";
                        break;
                }

                // Seting the loginOutputText to the error message
                registerOutputText.text = output;

            } else {

                Debug.Log("Logged In Specials");

                UserProfile profile = new UserProfile {

                    DisplayName = _username,

                };

                var defaultUserTask = user.UpdateUserProfileAsync(profile);

                yield return new WaitUntil(predicate: () => defaultUserTask.IsCompleted);

                if(defaultUserTask.Exception !=null) {

                    user.DeleteAsync();

                    FirebaseException firebaseException = (FirebaseException)defaultUserTask.Exception.GetBaseException();
                    AuthError error = (AuthError)firebaseException.ErrorCode;
                    string output = "Unknown Error, Please Try Again";

                    switch (error){

                        case AuthError.Cancelled:
                            output = "Update User Cancelled";
                            break;
                        case AuthError.SessionExpired:
                            output = "Session Expired";
                            break;
                        
                    }
                    registerOutputText.text = output;

                } else {

                    Debug.Log($"Firebase User Created Successfully: {user.DisplayName} ({user.UserId})");
                    //GameManager.instance.ChangeScene(1);
                    //StartCoroutine(SendVerificationEmail());
                    loadSceneManager.LoadLevel("Lobby");

                }

            }

        }

    }

    // private IEnumerator SendVerificationEmail() {
        
    //     if(user != null) {
            
    //         var emailTask = user.SendEmailVerificationAsync();

    //         yield return new WaitUntil(predicate: () => emailTask.IsCompleted); 

    //         if (emailTask.Exception != null) {

    //             FirebaseException firebaseException = (FirebaseException)emailTask.Exception.GetBaseException();
    //             AuthError error = (AuthError)firebaseException.ErrorCode;

    //             string output = "Unknown Error, Try Again!";

    //             switch (error) {

    //                 case AuthError.Cancelled:
    //                     output = "Verification Task was Cancelled";
    //                     break;
    //                 case AuthError.InvalidRecipientEmail:
    //                     output = "Invalid Email";
    //                     break;
    //                 case AuthError.TooManyRequests:
    //                     output = "Too Many Requests";
    //                     break;
                
    //             }

    //             AuthUIManager.instance.AwaitVerification(false, user.Email, output);


    //         } else {

    //             AuthUIManager.instance.AwaitVerification(true, user.Email, null);
    //             Debug.Log("Email Sent Successfully");

    //         }

    //     } 

    // }

}

