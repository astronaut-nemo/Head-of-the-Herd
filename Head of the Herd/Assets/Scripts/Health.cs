using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // References
    public GameManager gameManager;

    // Variables
    [SerializeField] private int health = 100; // Holds the current amount of health
    private int MAX_HEALTH = 100; // Holds the maximum value of health

    // Start is called once at the beginning
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Damage(10);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Heal(10);
        }
    }

    // Setting health value
    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    // Getting damage
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        
        this.health -= amount; // Reduce health by damage taken

        if(health <= 0)
        {
            // If the health is zero and below, the object dies
            Die();
            health = 0; // Cap health at zero
        }
    }

    // Healing
    public void Heal(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
        }

        // Check if health is over the Max Health value
        bool isOverMaxHealth = (health + amount > MAX_HEALTH);
        
        if(isOverMaxHealth)
        {
            this.health = MAX_HEALTH; // Cap health at Max Health
        }
        else
        {
            this.health += amount; // Increase health by heal
        }
    }

    // Death
    private void Die()
    {
        Debug.Log(this.gameObject + " is dead");
        Destroy(this.gameObject);
    }
}
