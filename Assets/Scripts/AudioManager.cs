using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base code from Naoise Collin's classes, Github link:
//https://github.com/naoisecollins/GD2BPlayerController/blob/main/Assets/Scripts/AudioManager.cs
//
//Slightly modified by me
//Jakub Polacek


public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioClip jumpClip;
    public AudioClip footstepSound;
    public AudioClip backgroundMusic;

    private AudioSource soundEffectSource;
    private AudioSource backgroundMusicSource;
    private AudioSource footstepSoundSource;


    void Awake() {

       if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
       }
       else {
            Destroy(gameObject);
            return;
       }

        soundEffectSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        footstepSoundSource = gameObject.AddComponent<AudioSource>();


        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();

        footstepSoundSource.clip = footstepSound;

    }

    

    public void PlayJumpSound() {
        soundEffectSource.PlayOneShot(jumpClip);
    }

    public void PlayFootstepSound() {

        if (!footstepSoundSource.isPlaying)
        {
            footstepSoundSource.PlayOneShot(footstepSound);
        }
        
    }

    public void PlayBackgroundMusic() {
        
        if (!backgroundMusicSource.isPlaying) {
            backgroundMusicSource.Play();
        }
    }

    public void PauseBackgroundMusic() {
        backgroundMusicSource.Pause();
    }

    public void StopBackgroundMusic() {
        backgroundMusicSource.Stop();
    }

    public void SetBackgroundMusicVolume(float volume) {
        backgroundMusicSource.volume = volume;
    }

}
