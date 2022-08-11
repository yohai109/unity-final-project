using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class EscapeMenuScript : MonoBehaviour
{
    //public Canvas quitMenu;
    public Text pauseText;
    public Button startText;
    public Button exitText;
    public Button mainMenuText;
    private MouseLook mouseLook;

    private bool menuEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseText.enabled = false;
        startText.gameObject.SetActive(false);
        exitText.gameObject.SetActive(false);
        mainMenuText.gameObject.SetActive(false);

        mouseLook = new MouseLook();
        //GameObject.FindWithTag("Player").GetComponent<RigidbodyFirstPersonController>().mouseLook.lockCursor = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseMenuHandler(bool pauseMenuEnabled)
    {
        pauseText.enabled = pauseMenuEnabled;
        startText.gameObject.SetActive(pauseMenuEnabled);
        exitText.gameObject.SetActive(pauseMenuEnabled);
        mainMenuText.gameObject.SetActive(pauseMenuEnabled);

        menuEnabled = pauseMenuEnabled;
    }

    void Update()
    {
        if (menuEnabled)
        {
            mouseLook.lockCursor = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //canvas.PauseMenuHandler(!enterMenu);
            //Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ExitPress()
    {
        //quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        // quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        /*SceneManager.LoadScene("GameScene");*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        mouseLook = new MouseLook();
        mouseLook.lockCursor = false;
        Cursor.visible = true;
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
