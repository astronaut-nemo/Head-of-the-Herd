using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // References
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] sheepPrefab;
    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;

    // Sheep Variables
    public int herdSize;
    
    // Game Stats
    public int score;
    public int highScore;
    public string playerRank;
    private string[] playerTitles = new string[] {"Bunty Beginner", "Wooly Apprentice", "Sure-footed Shepherd", "Head of the Herd"};
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerRankText;

    // Spawning Variables
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
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Spawner(maxEnemyInterval, enemyPrefab));
        StartCoroutine(Spawner(maxSheepInterval, sheepPrefab));

        herdSize = 0;
        highScore = 30;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        PlayerRanking();

        // Randomise spawn intervals
        enemySpawnInterval = Random.Range(0, maxEnemyInterval);
        sheepSpawnInterval = Random.Range(0, maxSheepInterval);
    }

    void UpdateScore(){
        score = herdSize;

        if(score > highScore){
            highScore = score;
        }

        scoreText.text = score +"/"+ highScore;
    }

///////////////////////////////////////////////////////////////////////////////////////////////

    /* UI MANAGEMENT */
    // Display current score and high score

    // Give the player a title based on their high score
    void PlayerRanking(){
        if(highScore <= 5){
            playerRank = playerTitles[0];
            playerRankText.text = playerRank;
        }
        else if(highScore > 5 && highScore <= 10){
            playerRank = playerTitles[1];
            playerRankText.text = playerRank;
        }
        else if(highScore > 10 && highScore <= 20){
            playerRank = playerTitles[2];
            playerRankText.text = playerRank;
        }
        else if(highScore > 20){
            playerRank = playerTitles[3];
            playerRankText.text = playerRank;
        }
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
    }

    public void ResumeGame()
    {
        // Pause game from running in background
        Time.timeScale = 1.0f;
    }

    /* END OF GAME STATES*/

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
