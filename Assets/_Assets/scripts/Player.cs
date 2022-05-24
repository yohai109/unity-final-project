using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float health,
        maxHealth;
    public HealthBar healthBar;
    private bool enterMenu = false;

    public EscapeMenuScript escapeCanvas;

    public DragonScript dragon;

    public CanvasScript canvas;
    private string textBoxText = "THE DRAGON GOT FASTER";

    void Start()
    {
        Time.timeScale = 1;
        healthBar.UpdateHealthBar();
    }

    public void TakeDamage(int damageMultipliyer)
    {
        // Use your own damage handling code, or this example one.
        if (health - (0.25f * damageMultipliyer) <= 0)
        {
            health = 0f;
            SceneManager.LoadScene("loseMenuScene");
        }
        else if (health - (0.25f * damageMultipliyer) >= 1)
        {
            health = 1f;
        }
        else
        {
            health -= (0.25f * damageMultipliyer);
        }

        healthBar.UpdateHealthBar();
    }

    void Update()
    {
        // Example so we can test the Health Bar functionality
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     TakeDamage(1);
        // }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escapeCanvas.PauseMenuHandler(!enterMenu);
            Time.timeScale = 1 * Convert.ToInt32(enterMenu);
            enterMenu = !enterMenu;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trap")
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HPPostion")
        {
            TakeDamage(-1);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Dragon")
        {
            TakeDamage(2);
        }
        else if (other.tag == "Box")
        {
            dragon.nextLevel();
            TakeDamage(-1);
            Destroy(other.gameObject);
            StartCoroutine(canvas.ShowText(textBoxText, 0, 3));
        }
    }

         
    // private IEnumerator ShowText(int seconds)
    // {
    //     textBox.text = "textBoxText";
    //     yield return new WaitForSeconds(seconds);
    //     textBox.enabled = true;
    //     yield return new WaitForSeconds(seconds);
    //     textBox.enabled = false;
    // }
}
