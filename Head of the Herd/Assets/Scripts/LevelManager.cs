using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;

    // Sheep Variables
    public int herdSize;
   
    
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;
        herdSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    /* GAME STATES */

    public void GameOver()
    {
        // Stop game from running in background
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void PauseGame()
    {
        // Pause game from running in background
        Time.timeScale = 0f;
        pauseGamePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        // Resume normal game time
        Time.timeScale = 1.0f;
        pauseGamePanel.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the Game and close the application
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    /* END OF GAME STATES*/



//////////////////////////////////////////////////////////////////////////////////////////////
    /* LEVEL MANAGEMENT */

    // Loads the specified scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
    /* END OF LEVEL MANAGEMENT */

/////////////////////////////////////////////////////////////////////////////////////////////
    /* SPAWN MANAGERS */
}
