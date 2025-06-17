using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetScript : MonoBehaviour
{
    
    private Rigidbody rb;

    [Range(0, 10)]
    public float rollSpeed = 5;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Health
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        healthBar.setHealth(currentHealth);
        //Health
    }

    // Update is called once per frame
    void Update()
    {
        //Health
        if (Input.GetKeyDown(KeyCode.D))
        {
            takeDamage(5);
            healthBar.setHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            takeDamage(10);
            healthBar.setHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            heal(20);
            healthBar.setHealth(currentHealth);
        }
        //Health
    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, rollSpeed);
    }


    // (HealthStuff)

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public void takeDamage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }

        gameManager.DecreaseScore();
        healthBar.setHealth(currentHealth);
    }

    public void heal(int heal)
    {
        if (currentHealth + heal >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal;
        }

        gameManager.IncreaseScore();
        healthBar.setHealth(currentHealth);
    }
}
