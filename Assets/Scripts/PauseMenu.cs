using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    
    public GameObject pauseMenuPanel;
    private bool paused = false;

    public void Start(){
        pauseMenuPanel.SetActive(false);
    }

    public void Update () {
        if (Input.GetKeyDown("escape")) {
            if(paused == true){
                Time.timeScale = 1.0f;
                pauseMenuPanel.SetActive(false);
                paused = false;
            } else {
                Time.timeScale = 0.0f;
                pauseMenuPanel.SetActive(true);
                paused = true;
            }
        }
    }
    public void Resume(){
        Time.timeScale = 1.0f;
        pauseMenuPanel.SetActive(false);
    }
}  