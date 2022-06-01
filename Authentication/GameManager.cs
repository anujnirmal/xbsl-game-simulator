using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public FirebaseManager firebaseManager;
   public GameObject MainMenu;

   public LoadingSceneManager loadSceneManager;

   public string path;

   private void Awake() {

       path = Application.persistentDataPath + "/player.anuj";
       
       DontDestroyOnLoad(gameObject);
       

       if(instance == null) {

           instance = this;
       
       } else if(instance != this) {

           Destroy(gameObject);

       }

   }


    // private void Start() {
        
    //   firebaseManager.AutoLoginCustomButton();  

    // }

   public void ChangeScene(string sceneName){

       loadSceneManager.LoadLevel(sceneName);
       //SceneManager.LoadSceneAsync(_sceneIndex);
   
   }

    public void StartNewGame(){

        Debug.Log("New Game Called");
        File.Delete(path);
        MainMenu.SetActive(false);
        loadSceneManager.LoadLevel("Level1");
        //GameManager.instance.ChangeScene("Lobby");
        //SceneManager.LoadScene(2);
    
    }

    public void ExitGame(){

        Application.Quit();

    }

    public void OpenMenu(){

        MainMenu.SetActive(true);

    }

}
