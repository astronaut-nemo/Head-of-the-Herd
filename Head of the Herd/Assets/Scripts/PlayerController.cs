using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // Add Rigidbody components and prevent them from being deleted
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    // References
    [SerializeField] private Rigidbody playerRb; // Holds ref. to player Rigidbody component
    [SerializeField] private FixedJoystick joystick; // Holds ref. to fixed joystick component

    // Variables
    [SerializeField] private float moveSpeed; // Holds player speed variable
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector3(joystick.Horizontal * moveSpeed, playerRb.velocity.y, joystick.Vertical * moveSpeed);  // Input from the joystick controls the player movement in x- and z-axes
    }
}
