using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [SerializeField]
    private string gameSceneName = "GameScene";
    [SerializeField]
    private string optionsSceneName = "OptionScene";

    public void StartGame() {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions() {
        SceneManager.LoadScene(optionsSceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }

    //Last loaded scene: 0 - main menu
    private void OnDestroy() {
        GameManager.instance.previousScene = 0;
    }
}
