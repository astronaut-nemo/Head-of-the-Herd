using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Controls player shooting mechanics

public class PlayerController : MonoBehaviour
{
    // References
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject projectilePrefab;

    // Updates each frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           Shoot();
        }
    }

    // Shooting Mechanic
    private void Shoot()
    {
         // Spawn stones in direction player is facing
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
    }
}
