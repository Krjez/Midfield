using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

    [SerializeField]
    private string mainMenuName = "MainMenuScene";

    private int previousScene = GameManager.instance.previousScene;

    public void OpenMainMenu() {
        SceneManager.LoadScene(mainMenuName);
    }

    public void BackButton() {
        SceneManager.LoadScene(previousScene);
    }

    public void setVolume(float volume) {
        AudioManager.instance.SetBackgroundMusicVolume(volume);
    }

    //Last loaded scene: 2 - options menu
    private void OnDestroy() {
        GameManager.instance.previousScene = 2;
    }
}