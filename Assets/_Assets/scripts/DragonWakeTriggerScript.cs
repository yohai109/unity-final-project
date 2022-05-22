using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonWakeTriggerScript : MonoBehaviour
{
    public DragonScript dragon;
    public Text textBox;
    private bool flag = false;
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
        if (Physics.Raycast(transform.position, Vector3.right, out hit, rayLength)) {
            if (hit.collider.gameObject.tag == "Player") {
                dragon.Wake();
                StartCoroutine(ShowText(5));
            }
        }

        // if (flag) {
        //     textBox.enabled = true;
        //      StartCoroutine(Wait(5));
        // } else {
        //     Debug.Log("else " + flag);
        //     textBox.enabled = false;
        // }

    }

    private IEnumerator ShowText(int seconds) {
        yield return new WaitForSeconds(seconds);
        textBox.enabled = true;
        yield return new WaitForSeconds(seconds);
        textBox.enabled = false;
    }
}
