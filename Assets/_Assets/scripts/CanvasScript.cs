using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    public Text warningTextBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowText(string textToShow, int delayInSeconds, int showInSeconds) {
        warningTextBox.text = textToShow;
        yield return new WaitForSeconds(delayInSeconds);
        warningTextBox.enabled = true;
        yield return new WaitForSeconds(showInSeconds);
        warningTextBox.enabled = false;
    }
}
