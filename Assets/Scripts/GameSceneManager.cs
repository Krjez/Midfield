using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    [SerializeField]
    private string optionsSceneName = "OptionScene";

    public bool isPaused = false;

    void Update() {

        if (Input.GetKeyDown(KeyCode.P)) {
            if (isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(optionsSceneName);
        }

    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        //this is for pause menu
        //if use same thing but 0.1 - "slow motion"
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        //turn off pause menu
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Last loaded scene: 1 - game scene
    private void OnDestroy() {
        GameManager.instance.previousScene = 1;
    }


}
