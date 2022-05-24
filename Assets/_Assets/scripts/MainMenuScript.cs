using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
public class MainMenuScript : MonoBehaviour
{
    //public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = new MouseLook();
        mouseLook.lockCursor = false;
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        Cursor.visible = true;
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
        SceneManager.LoadScene("GameScene");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
