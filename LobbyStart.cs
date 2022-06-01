using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LobbyStart : MonoBehaviour
{
    private int level;
    private string path;

    public LoadingSceneManager loadSceneManager;

    
    private void Awake() {

        path = Application.persistentDataPath + "/player.anuj";
    
    }
    public void StartGame(){

      

        if(File.Exists(path)) {

            PlayerData data = SaveSystem.LoadPlayer();
            
            Debug.Log(level = data.level);
            level = data.level;


            // Calling the loading manager
            loadSceneManager.LoadLevel("level1");
            //SceneManager.LoadScene(level + 1);
        
        } else {
            
            loadSceneManager.LoadLevel("level1");
            //SceneManager.LoadScene("level1");
        
        }

        
        //SceneManager.LoadScene("level1");

    }

    public void StartNewGame(){

        File.Delete(path);
        // Calling the Start scene loading to start the loading 
        // Progres bar is activated
        loadSceneManager.LoadLevel("Level1");
        //SceneManager.LoadScene("Level1");

    }

    public void SignOutUser(){

        FirebaseManager.instance.UserSignOut();

    }

    public void GameQuit(){

        Application.Quit();

    }

}
