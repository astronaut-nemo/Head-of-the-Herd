using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //
    public static LevelManager Instance;


    void Awake()
    {
        // Don't delete on new scene load
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // If Instance already exists, destroy this Instance
        {
            Destroy(gameObject);
        }
    }

    // Loads the specified scene
    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
    }
}
