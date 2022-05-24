using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DragonWakeTriggerScript : MonoBehaviour
{
    public DragonScript dragon;
    public CanvasScript canvas;
    private static string textBoxText = "RUN" ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int rayLength = 30;
        Debug.DrawRay(transform.position, Vector3.right * rayLength, Color.green);
        if (Physics.Raycast(transform.position, Vector3.right, out hit, rayLength))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                dragon.Wake();
                StartCoroutine(canvas.ShowText(textBoxText, 5, 5));
            }
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
