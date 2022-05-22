using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Utility;
public class EscapeMenuScript : MonoBehaviour
{
    //public Canvas quitMenu;
    public Text pauseText;
    public Button startText;
    public Button exitText;
    
    private bool menuEnabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseText.enabled = false;
        startText.gameObject.SetActive(false);
        exitText.gameObject.SetActive(false);
    }

    public void PauseMenuHandler(bool pauseMenuEnabled) {
        pauseText.enabled = pauseMenuEnabled;
        startText.gameObject.SetActive(pauseMenuEnabled);
        exitText.gameObject.SetActive(pauseMenuEnabled);

        menuEnabled = pauseMenuEnabled;
    }

    void Update() {
        // if (menuEnabled) {
        //         mouseLook = new MouseLook();
        //         mouseLook.lockCursor = false;
        //         Cursor.visible = true;
        //         canvas.PauseMenuHandler(!enterMenu);
        // Cursor.visible = true;
    }

    public void ExitPress() {
        //quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

public void NoPress() {
        // quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel () {
        SceneManager.LoadScene("GameScene");
    }


    public void ExitGame (){
        Application.Quit();
    }
}
