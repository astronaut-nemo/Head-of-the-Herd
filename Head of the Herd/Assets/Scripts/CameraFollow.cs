using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // References
    public GameObject player; // Holds reference to the player object

    // Variables
    public Vector3 offset = new Vector3(0, 0, 10); // Holds offset distance from player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Set camera to follow player
    }
}
