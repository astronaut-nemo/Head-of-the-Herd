using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    //
    private GameObject[] enemyArray;
    public Transform closestEnemy;
    public bool enemyContact;

    // Start is called before the first frame update
    void Start()
    {
        // Initalising variables
        closestEnemy = null;
        enemyContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Searching for enemies
    public Transform GetClosestEnemy()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy"); // Find every enemy object in scene
        float closestDistance = Mathf.Infinity; // Search at maximum possible distance
        Transform closestEnemyTransform = null;

        foreach(GameObject enemy in enemyArray)
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position); // Find distance between enemy in array and player
            
            // If the enemy is the closest ever, then set closest distance to that distance and return that enemy's transform
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestEnemyTransform = enemy.transform;
            }
        }

        // Return the transform of the closest enemy
        return closestEnemyTransform;
    }

    // Collision Triggers
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            closestEnemy = GetClosestEnemy();
            Debug.Log(closestEnemy + "has entered the radar");
            enemyContact = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyContact = false;
    }
}