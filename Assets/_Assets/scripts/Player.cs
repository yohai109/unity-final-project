using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float health, maxHealth;
    public HealthBar healthBar;

    void Start() {
        healthBar.UpdateHealthBar();
    }
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.
        health = health - 0.25f;
        healthBar.UpdateHealthBar();
    }
    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }
}
