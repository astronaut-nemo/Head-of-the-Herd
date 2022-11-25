using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add Rigidbody components and prevent them from being deleted
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class JoystickControl : MonoBehaviour
{
    // References
    [SerializeField] private Rigidbody playerRb; // Holds ref. to player Rigidbody component
    [SerializeField] private FixedJoystick joystick; // Holds ref. to fixed joystick component
    // [SerializedField] private Animator playerAnimator; // Holds ref. to player Animator component
    // public ParticleSystem dustParticle;

    // Variables
    private Vector3 playerInput; // Holds player Input
    [SerializeField] private float playerSpeed = 5; // Holds value for speed of movement
    [SerializeField] private float turnSpeed = 360; // Holds value for angle for rotation as one full rotation

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
        // Add buffer so palyer only moves if joystick is pushed far; alternatively you can have a speed control
        playerInput = new Vector3(joystick.Horizontal * playerSpeed, 0, joystick.Vertical * playerSpeed); // Get player inputs for the x- and z-axes
    }

    // Rotate player to look around
    private void LookAround()
    {
        if(playerInput != Vector3.zero)
        {
            var rotMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0)); // Skew the player input to account for isometric view
            var skewedPlayerInput = rotMatrix.MultiplyPoint3x4(playerInput); // Multiplying vector by input to get new iso input
            
            var relativePos = (transform.position + skewedPlayerInput) - transform.position; // Find relative angle between where we are and where we want to be
            var playerRotation = Quaternion.LookRotation(relativePos, Vector3.up); // Pass desired position to variable playerRotation

            transform.rotation = Quaternion.RotateTowards(transform.rotation, playerRotation, turnSpeed * Time.deltaTime); // Set current object rotation to rotation based on the user input
        }
    }

    // Move player based on user input
    void MovePlayer()
    {
        playerRb.MovePosition(transform.position + transform.forward * playerInput.normalized.magnitude * playerSpeed * Time.deltaTime);
        // play dust particle system
        // dustParticle.Play();
    }
}
