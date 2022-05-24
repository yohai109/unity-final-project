using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DragonWakeTriggerScript : MonoBehaviour
{
    public DragonScript dragon;
    public Text textBox;
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
                StartCoroutine(ShowText(5));
            }
        }
    }

    private IEnumerator ShowText(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        textBox.enabled = true;
        yield return new WaitForSeconds(seconds);
        textBox.enabled = false;
    }
}
