using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Button startNewGameButton;

    public LoadingSceneManager loadSceneManager;

    public string path;
    private void Awake() {

        // Getting the file location
        path = Application.persistentDataPath + "/player.anuj";
    
    }

    void Start()
    {
        
        //Setting an event listener for the new button
        startNewGameButton.onClick.AddListener(StartNewGameFunc);

    }

    public void StartNewGameFunc(){

        Debug.Log("Called here");
        // Deleting the stored file
        File.Delete(path);
        //Loading scene level
        loadSceneManager.LoadLevel("Level1");

    }

    public void ExitTheGame(){

        Application.Quit();

    }
        
    
}
