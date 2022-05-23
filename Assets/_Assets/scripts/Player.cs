using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float health, maxHealth;
    public HealthBar healthBar;
    private bool enterMenu = false;
    MouseLook mouseLook;

    public EscapeMenuScript canvas;

    void Start() {
        healthBar.UpdateHealthBar();
        //mouseLook = new MouseLook();
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

        // mouseLook.lockCursor = enterMenu;
        // Cursor.visible = enterMenu;
        
        
        if (Input.GetKeyUp(KeyCode.Escape)) {
            canvas.PauseMenuHandler(!enterMenu);
            enterMenu = !enterMenu;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Trap") {
            TakeDamage(1);
        }
    }
}
