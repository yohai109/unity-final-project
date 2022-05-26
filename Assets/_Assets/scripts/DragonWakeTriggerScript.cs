using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DragonWakeTriggerScript : MonoBehaviour
{
    public DragonScript dragon;
    public CanvasScript canvas;
    private static string textBoxText = "RUN";
    private bool dragonGotAwake = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int rayLength = 50;
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.left * rayLength, Color.green);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.left, out hit, rayLength))
        {
            Debug.Log("object entered ray");
            if (hit.collider.gameObject.tag == "Player" && !dragonGotAwake)
            {
                dragonGotAwake = false;
                Debug.Log("Dragon got awake");
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
