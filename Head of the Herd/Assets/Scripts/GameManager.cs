using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Sheep Variables
    public int herdSize;
    public float herdAngle;

    // References
    [SerializeField] private GameObject[] animalPrefab;

    // Variables
    [SerializeField] private float spawnRangeX = 40;
    [SerializeField] private float spawnRangeZ = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnManager();
    }

// Controls the spawning in randomised positions
    void SpawnManager()
    {
        int index = Random.Range(0, animalPrefab.Length);
        spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        Instantiate(animalPrefab[index], randomSpawnPos, animalPrefab[index].transform.rotation);
    }
}
