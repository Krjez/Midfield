using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    [Header("Game States")]

    public bool isPaused;
    public bool isGameOver;


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

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        //this is for pause menu
        //if use same thing but 0.1 - "slow motion"
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        //turn off pause menu
    }

    public void GameOver()
    {
        isGameOver = true;
        //add what happens after
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
