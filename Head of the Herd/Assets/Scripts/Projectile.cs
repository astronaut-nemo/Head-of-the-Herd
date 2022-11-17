using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // References
    [SerializeField] private ProjectileData data;
    [SerializeField] private Vector3 firingPoint;
    
    // Variables
    [SerializeField] private float maxProjectileDistance = 10;
    [SerializeField] private int projectileDamage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponValues();
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

    // Collisions
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            // Reduce enemy health
            Debug.Log("Reduce health by amount");
            if(other.GetComponent<Health>() != null){
                Debug.Log("Get Wrecked Enemy!");
                other.GetComponent<Health>().Damage(projectileDamage);
            }
        }
    }

    // Set projectile values according to the data values in the Inspector
    private void SetWeaponValues()
    {
        maxProjectileDistance = data.travelDistance;
        projectileDamage = data.damage;
    }
}

