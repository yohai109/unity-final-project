using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public DragonScript dragon;
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
                if (dragon.isDragonAsleep())
                {
                    SceneManager.LoadScene("WinningMenuScene");
                }
                else
                {
                    dragon.die();
                }
            }
        }
    }
}
