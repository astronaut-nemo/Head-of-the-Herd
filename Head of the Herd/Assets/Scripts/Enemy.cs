using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // References
    [SerializeField] private EnemyData data; // Holds reference to the enemy stats
    [SerializeField] private GameObject player; // Holds reference to the player object
    public ParticleSystem bloodSplatter;

    // Variables
    // [SerializeField] private int damage = 5; // Holds default amount of damage to deal
    [SerializeField] private float speed = 1.5f; // Holds default amount of speed
    
    // Start is called before the first frame update
    void Start()
    {
        SetEnemyValues(); // Set the enemy data
        player = GameObject.FindGameObjectWithTag("Player"); // Set reference to player in scene
    }

    // Update is called once per frame
    void Update()
    {
        SwarmPlayer();
    }


    // Set enemy values according to the data values in the Inspector
    private void SetEnemyValues()
    {
        this.GetComponent<Health>().SetHealth(data.hp, data.hp);
        // damage = data.damage;
        speed = data.speed;
    }

    // Enemy movement definition
    private void SwarmPlayer()
    {
        // Look at and move towards player
        transform.LookAt(player.transform);
        Vector3 playerPosEnemyHeight = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPosEnemyHeight, speed * Time.deltaTime); 
    }
}
