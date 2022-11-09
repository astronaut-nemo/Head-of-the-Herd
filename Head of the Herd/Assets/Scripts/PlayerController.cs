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
    // [SerializedField] private Animator playerAnimator; // Holds ref. to player Animator component

    // Variables
    private Vector3 playerInput; // Holds player Input
    [SerializeField] private float playerSpeed = 5; // Holds value for speed of movement

    // Updates each frame
    void Update()
    {
        GatherInput();
        LookAround();
    }
    
    void FixedUpdate()
    {
        MovePlayer();
    }


    // Gather player input
    private void GatherInput()
    {
        playerInput = new Vector3(joystick.Horizontal * playerSpeed, 0, joystick.Vertical * playerSpeed); // Get player inputs for the x- and z-axes
    }

    // Rotate player to look around
    private void LookAround()
    {
        // Find relative distance between where we are and where we want to be
        var relativePos = (transform.position + playerInput) - transform.position;
        var playerRotation = Quaternion.LookRotation(relativePos, Vector3.up); // Pass desired position to variable playerRotation

        transform.rotation = playerRotation; // Set current object rotation to that based on the user input
    }

    // Move player based on user input
    void MovePlayer()
    {
        playerRb.MovePosition(transform.position + transform.forward * playerInput.normalized.magnitude * playerSpeed * Time.deltaTime);
    }
}
