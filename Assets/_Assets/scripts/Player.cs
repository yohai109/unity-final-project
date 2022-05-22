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
    public void TakeDamage(int damageMultipliyer)
    {
        // Use your own damage handling code, or this example one.
        health = health - 0.25f * damageMultipliyer;
        healthBar.UpdateHealthBar();
    }
    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Trap") {
            TakeDamage(1);
        }
    }
}
