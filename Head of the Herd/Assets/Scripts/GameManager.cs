using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // References
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] sheepPrefab;
    public GameObject gameOverPanel;

    // Sheep Variables
    public int herdSize;
    public float herdAngle;

    // Variables
    [SerializeField] private float enemySpawnInterval;
    [SerializeField] private float maxEnemyInterval = 3.5f;
    [SerializeField] private float sheepSpawnInterval;
    [SerializeField] private float maxSheepInterval = 5.0f;
    [SerializeField] private float spawnRangeX = 40;
    [SerializeField] private float spawnRangeZ = 40;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner(maxEnemyInterval, enemyPrefab));
        StartCoroutine(Spawner(maxSheepInterval, sheepPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        // Randomise spawn intervals
        enemySpawnInterval = Random.Range(0, maxEnemyInterval);
        sheepSpawnInterval = Random.Range(0, maxSheepInterval);
    }

///////////////////////////////////////////////////////////////////////////////////////////////
    /* GAME STATES */
    public void GameOver()
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
    // Spawning method
    private IEnumerator Spawner(float interval, GameObject[] objectPrefab)
    {
        // Interval to wait
        yield return new WaitForSeconds(interval);

        // Random object to spawn from Prefab
        int index = Random.Range(0, objectPrefab.Length);
        // Instantiate at random position
        Instantiate(objectPrefab[index], GenerateSpawnPosition(), objectPrefab[index].transform.rotation);

        // Call the coroutine again
        StartCoroutine(Spawner(interval, objectPrefab));
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
