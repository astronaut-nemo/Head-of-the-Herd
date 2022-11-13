using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // References
    [SerializeField] private EnemyData data; // Holds reference to the 
    [SerializeField] private GameObject player; // Holds reference to the player object

    // Variables
    [SerializeField] private int damage = 5; // Holds default amount of damage to deal
    [SerializeField] private float speed = 1.5f; // Holds default amount of speed
    
    // Start is called before the first frame update
    void Start()
    {
        SetEnemyValues(); // Set the enemy data
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
        damage = data.damage;
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

    // If collide with bullet, destroy
    // If collide with sheep, destroy both and one point down

    private void onTriggerEnter(Collider other)
    {
        
        Debug.Log("contact");
        // If colliding with the player, deal damage, game over
        if(other.CompareTag("Player"))
        {
            Debug.Log("Enemy deals damage");

            /*if(collider.GetComponent<Health>() != null) // Check if Health.cs is attached to the player
            {
                collider.GetComponent<Health>().Damage(damage); // Deal the enemy type damage
                Debug.Log("Get Wrecked!");
            }*/
        }
    }
}
