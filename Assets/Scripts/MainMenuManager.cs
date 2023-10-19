using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    [SerializeField]
    private string gameSceneName = "GameScene";
    [SerializeField]
    private string optionSceneName = "OptionScene";

    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadScene(gameSceneName);
        
    }

    public void OpenOptions() {
        SceneManager.LoadScene(optionSceneName);
    }

    public void QiutGame() {
        Application.Quit();
    }
}
