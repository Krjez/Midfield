using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    [SerializeField]
    private string optionsSceneName = "OptionScene";

    public bool isPaused = false;
    public Canvas CanvasObject;

    private void Awake() {
        CanvasObject.enabled = false;
    }

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

    //Pauses game and displays canvas with message
    public void PauseGame() {
        isPaused = true;
        Time.timeScale = 0f;
        CanvasObject.enabled = true;
    }

    //Resumes game and removes the canvas
    public void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1f;
        CanvasObject.enabled = false;
    }

    //Last loaded scene: 1 - game scene
    private void OnDestroy() {
        GameManager.instance.previousScene = 1;
    }

}
