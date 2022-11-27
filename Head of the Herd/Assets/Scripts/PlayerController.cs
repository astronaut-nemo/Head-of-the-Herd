using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Controls player shooting mechanics

public class PlayerController : MonoBehaviour
{
    // References
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameManager gameManager;

    // Start is called once at the beginning
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Updates each frame
    void Update()
    {
        /* FOR DEBUGGING PURPOSES */
        if(Input.GetKeyDown(KeyCode.Space))
        {
           Shoot();
        }
    
    }

    // Shooting Mechanic
    public void Shoot()
    {
         // Spawn stones in direction player is facing
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
    }

    // Collisions
    void OnTriggerEnter(Collider other)
    {
        // If player collides with an enemy, the game is over
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("You've been hit!");
            CameraShake.Shake(0.5f, 0.5f);
            gameManager.GameOver();
        }
    }
}
