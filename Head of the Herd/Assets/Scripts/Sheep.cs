using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // References
    public static GameObject herdCenter; // Holds reference to the player object

    // Variables
    public bool isInRange; // Checks if the sheep is in the range
    public float maxAttractDistance; // Holds the range at which a sheep is attracted into the herd
    
    // Start is called before the first frame update
    void Start()
    {
        herdCenter = GameObject.FindGameObjectWithTag("Herd Center");
    }

    // Update is called once per frame
    void Update()
    {
        // check if sheep is in range and attract to herd
        SheepAttraction();
    }

    // Check if in range
    void SheepAttraction()
    {
        float distanceToCenter = Vector3.Distance(transform.position, herdCenter.transform.position);

        // Check the distance between the sheep and herd center
        if(distanceToCenter <= maxAttractDistance)
        {
            isInRange = true;
            Debug.Log("Come 'ere sheep!");
            this.transform.SetParent(herdCenter.transform);
            
            OrbitHerdCenter();
            // if sheep is in range then add to parent group and start orbiting player: set parent and Orbit()
            // add the herd size and increase the attraction distance
        }

        else
        {
            isInRange = false;
        }
    }

    void OrbitHerdCenter()
    {
        // Rotate around the herd center
    }
}
