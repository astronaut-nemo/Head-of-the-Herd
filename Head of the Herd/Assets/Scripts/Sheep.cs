using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // References
    public static GameObject herdCenter; // Holds reference to object to rotate around
    public GameManager gameManager;

    // Variables
    public bool isInHerd = false; // Checks if the sheep is in the range
    public float maxAttractDistance; // Holds the range at which a sheep is attracted into the herd
    public float rotationSpeed; // Holds speed of orbiting rotation
    
    // Start is called before the first frame update
    void Start()
    {
        herdCenter = GameObject.FindGameObjectWithTag("Herd Center");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if sheep is in range and attract to herd where they orbit
        SheepAttraction();

        // Sheep orbit player as herd
        if(isInHerd)
        {
            OrbitHerdCenter();
        }

        // Depending on herd size, add the herd size and increase attraction distance
    }

    // Check if in range
    void SheepAttraction()
    {
        float distanceToCenter = Vector3.Distance(transform.position, herdCenter.transform.position);

        // Check the distance between the sheep and herd center
        if(distanceToCenter <= maxAttractDistance && !isInHerd)
        {
            // If sheep is in range then add to parent group
            Debug.Log("Come 'ere sheep!");
            this.transform.SetParent(herdCenter.transform);
            gameManager.herdSize = gameManager.herdSize + 1;
            
            // Arrange sheep in herd: on adding a sheep, check the size of the herd and calculate the angle between sheep in each ring. Each ring has a specified no of sheep it can hold


            isInHerd = true;
        }
    }

    // Sheep orbit around center
    void OrbitHerdCenter()
    {
        // Rotate around the herd center
        Debug.Log("Spin baby!");
        transform.RotateAround(herdCenter.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // On collision with predator, destroy, decrease score by one
}
