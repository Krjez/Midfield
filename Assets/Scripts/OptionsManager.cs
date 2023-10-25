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

    //Gets the current volume levels from audio manager so that the sliders display correctly at start
    private void Awake() {
        sliderEffects.value = AudioManager.instance.effectsVolume;
        sliderBackground.value = AudioManager.instance.backgroundVolume;
    }


    public void OpenMainMenu() {
        SceneManager.LoadScene(mainMenuName);
    }

    //Uses the previousScene to go back by one - anticipated more screens in future
    public void BackButton() {
        SceneManager.LoadScene(GameManager.instance.previousScene);
    }

    //Methods passed into the sliders
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
