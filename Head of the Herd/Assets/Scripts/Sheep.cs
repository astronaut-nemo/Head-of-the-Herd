using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // References
    public static GameObject herdCenter; // Holds reference to object to rotate around
    public GameManager gameManager;
    [SerializeField] private AudioClip sheepJoinClip; // Sound of sheep baa
    [SerializeField] private AudioClip sheepDieClip; // Sound of sheep die
    [SerializeField] private AudioClip enemyEatClip; // Sound of crunch

    // Variables
    public bool isInHerd = false; // Checks if the sheep is in the range
    public float maxAttractDistance; // Holds the range at which a sheep is attracted into the herd
    public float rotationSpeed; // Holds speed of orbiting rotation
    
    // Start is called before the first frame update
    void Start()
    {
        herdCenter = GameObject.FindGameObjectWithTag("Herd Center");
        gameManager = GameManager.instance;
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

    // Collisions
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && isInHerd){
            Debug.Log("Sheep is eaten");
            
            // Play blood particle effect
            GameManager.instance.PlayParticleFX(this.transform, "Blood Splatter");
            SoundManager.instance.PlaySound(enemyEatClip);

            gameManager.herdSize --;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
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
            
            // Arrange sheep in herd: on adding a sheep, check the size of the herd and calculate the angle between sheep in each ring. Each ring has a specified no of sheep it can hold
            // Maybe store new sheep children into an array and then use AI behaviour to control them

            isInHerd = true;
            SoundManager.instance.PlaySound(sheepJoinClip);
            gameManager.herdSize ++;
        }
    }

    // Sheep orbit around center
    void OrbitHerdCenter()
    {
        // Rotate around the herd center
        transform.RotateAround(herdCenter.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
