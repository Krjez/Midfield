using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    [SerializeField]
    private string mainMenuName = "MainMenuScene";

    [SerializeField]
    private Slider sliderEffects;
    [SerializeField]
    private Slider sliderBackground;

    private void Awake() {
        sliderEffects.value = AudioManager.instance.effectsVolume;
        sliderBackground.value = AudioManager.instance.backgroundVolume;
    }


    public void OpenMainMenu() {
        SceneManager.LoadScene(mainMenuName);
    }

    public void BackButton() {
        SceneManager.LoadScene(GameManager.instance.previousScene);
    }

    public void SetEffectsVolume(float volume) {
        AudioManager.instance.SetEffectsVolume(volume);
        AudioManager.instance.effectsVolume = volume;
    }

    public void SetBackgroundVolume(float volume) {
        AudioManager.instance.SetBackgroundMusicVolume(volume);
        AudioManager.instance.backgroundVolume = volume;
    }

    //Last loaded scene: 2 - options menu
    private void OnDestroy() {
        GameManager.instance.previousScene = 2;
    }
}
