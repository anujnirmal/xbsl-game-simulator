using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{

    public PlayerController player;
    public GameObject WinPanel;

    private int runWinOnce = 1;
    // Start is called before the first frame update
    private void Start() {
        
       
    }

    private void Update() {

        Debug.Log(player.MoneyBar);

        if (player.MoneyBar >= 100000){

            if (runWinOnce == 1) {
                
                WinPanel.SetActive(true);
                runWinOnce += 1;

            }
            

        }
        
    }


}
