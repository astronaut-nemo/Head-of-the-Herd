using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialGameManager : MonoBehaviour
{
//////////////////////////////////////////////////////////////////////////////////////////////
    
    /* LEVEL MANAGEMENT */
    // Loads the specified scene
    public async void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 1.0f;
    }
    /* END OF LEVEL MANAGEMENT */

/////////////////////////////////////////////////////////////////////////////////////////////
}
