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


    void Awake() {

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

        jumpSoundSource.clip = jumpClip;
        landingSoundSource.clip = landingClip;

        footstepSoundSource.clip = footstepSound;

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }



    public void PlayJumpSound() {
        jumpSoundSource.PlayOneShot(jumpClip);
    }

    public void PlayLandingSound() {
        landingSoundSource.PlayOneShot(landingClip);
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
