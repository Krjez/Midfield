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
    public AudioClip landingClip;
    public AudioClip footstepSound;
    public AudioClip backgroundMusic;

    private AudioSource jumpSoundSource;
    private AudioSource landingSoundSource;
    private AudioSource footstepSoundSource;
    private AudioSource backgroundMusicSource;

    public float effectsVolume = 0.7f;
    public float backgroundVolume = 0.7f;


    void Awake() {

        //Prevents being destroyed on new scenes
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }

        jumpSoundSource = gameObject.AddComponent<AudioSource>();
        landingSoundSource = gameObject.AddComponent<AudioSource>();
        footstepSoundSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();

        footstepSoundSource.clip = footstepSound;
        jumpSoundSource.clip = jumpClip;
        landingSoundSource.clip = landingClip;
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;

        SetEffectsVolume(effectsVolume);
        SetBackgroundMusicVolume(backgroundVolume);

        PlayBackgroundMusic();
    }



    public void PlayJumpSound() {
        jumpSoundSource.PlayOneShot(jumpClip);
    }

    public void PlayLandingSound() {
        landingSoundSource.PlayOneShot(landingClip);
    }

    //Because player movement is continuous, checks if there is already a clip playing to prevent it repeating over itself
    public void PlayFootstepSound() {

        if (!footstepSoundSource.isPlaying) {
            footstepSoundSource.PlayOneShot(footstepSound);
        }
    }

    public void PlayBackgroundMusic() {
        
        if (!backgroundMusicSource.isPlaying) {
            backgroundMusicSource.Play();
        }
    }

    public void SetBackgroundMusicVolume(float volume) {
        backgroundMusicSource.volume = volume;
    }

    public void SetEffectsVolume(float volume) {
        footstepSoundSource.volume = volume;
        jumpSoundSource.volume = volume;
        landingSoundSource.volume = volume;
    }

}
