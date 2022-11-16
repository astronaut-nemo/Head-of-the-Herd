using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // References
    [SerializeField] private Vector3 firingPoint;
    
    // Variables
    [SerializeField] private float maxProjectileDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        firingPoint = transform.position; // Save the position at which the projectile was spawned
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy fired projectiles after a certain distance
        if(Vector3.Distance(firingPoint, transform.position) > maxProjectileDistance)
        {
            Destroy(gameObject);
        }
    }

    // Hitting the enemy
    void onTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
    }
}

