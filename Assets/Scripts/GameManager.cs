using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Indestructible class used for storing information between scenes

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;

    public int previousScene;

    //First x and y are set same as starting position
    public float playerX = -6.25f;
    public float playerY = -3.55f;
    public Boolean isFlipped = false;

    void Awake() {

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
    }
}
