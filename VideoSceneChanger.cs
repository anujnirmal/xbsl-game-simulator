using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class VideoSceneChanger : MonoBehaviour
{

    public PlayableDirector timeline;
    public LoadingSceneManager levelLoader;
    // Start is called before the first frame update

    void OnEnable()
    {
        timeline.stopped += OnPlayableDirectorStopped;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    //     timeline.stopped += OnPlayableDirectorStopped;

    // }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (timeline == aDirector)
        levelLoader.LoadLevel("Level1");
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
    }

    void OnDisable()
    {
        timeline.stopped -= OnPlayableDirectorStopped;
    }
}
