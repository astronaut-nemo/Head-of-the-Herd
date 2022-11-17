using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // References
    [SerializeField] private GameObject[] enemyPrefab;
    public GameObject gameOverPanel;

    // Sheep Variables
    public int herdSize;
    public float herdAngle;

    // Variables
    [SerializeField] private float spawnRangeX = 40;
    [SerializeField] private float spawnRangeZ = 40;
    private int spawnIndex;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            GameOver();
        }

    }

///////////////////////////////////////////////////////////////////////////////////////////////
    /* GAME STATES */
    void GameOver()
    {
        // Stop game from running in background
        gameOverPanel.gameObject.SetActive(true);
    }

    // void PauseGame()
    // {
    //     // Pause game from in background
    //     pauseGamePanel.gameObject.SetActive(true);
    // }

    /* END OF GAME STATES*/

//////////////////////////////////////////////////////////////////////////////////////////////
    
    /* LEVEL MANAGEMENT */
    // Loads the specified scene
    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
    }
    /* END OF LEVEL MANAGEMENT */

/////////////////////////////////////////////////////////////////////////////////////////////
    /* SPAWN MANAGERS */
    // Spawning a wave
    void SpawnWave(GameObject[] objectPrefab)
    {
        int index = Random.Range(0, objectPrefab.Length);
        
        Instantiate(objectPrefab[index], GenerateSpawnPosition(), objectPrefab[index].transform.rotation);
    }

    // Generates random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
