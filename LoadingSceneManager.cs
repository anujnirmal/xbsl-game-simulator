using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{   
    public Slider levelLoaderProgressBar;
    public TMP_Text levelLoaderProgressText;
    public GameObject LevelLoaderScreen;
    public Animator animator;

    public void LoadLevel(string sceneName){

       LevelLoaderScreen.SetActive(true); 
       StartCoroutine(LoadAsynchronously(sceneName));

    }

    IEnumerator LoadAsynchronously(string sceneName) {

         // Loading the scene async
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone) {

            // Setting the value to 1
            float progress = Mathf.Clamp01(operation.progress / .9f);
            // Logging the operation to 1

            // Setting the slider value to the progress
            levelLoaderProgressBar.value = progress;
            // Setting the text to the percentage
            levelLoaderProgressText.text = (operation.progress) * 100 + "%";

            Debug.Log(operation.progress);

            // Waits one frame before the next while loop
            yield return null;

        }

        animator.SetTrigger("FadeOut");

    }

    public void FadeToLevel() {

        
        

    }

    public void OnFadeComplete(){

    }

}
