using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTutorialScript : MonoBehaviour
{
    public Canvas tutorialCanvas;
    public Text tutorialText;
    public GameObject tutorialPanel;
    private float fadeSpeed = 5;
    private bool entrenace = false;
    // Start is called before the first frame update

    private void Start() {
        tutorialText.color = Color.clear;
    }

    private void Update() {
        if (entrenace)
        {
            tutorialText.color = Color.Lerp(tutorialText.color, Color.white, fadeSpeed * Time.deltaTime);
            tutorialPanel.SetActive(true);

        }
        else
        {
            tutorialText.color = Color.Lerp(tutorialText.color, Color.clear, fadeSpeed * Time.deltaTime);
            tutorialPanel.SetActive(false);

        }    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            entrenace = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            entrenace = false;
        }
    }
}
