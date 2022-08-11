using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int range = 50;
    public Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.DrawRay(player.position, player.TransformDirection(Vector3.forward) * rayLength, Color.green, 100f);*/
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("hit");
            RaycastHit hit;
            if (Physics.Raycast(player.position, player.TransformDirection(Vector3.forward), out hit, range))
            {
                if (hit.collider.gameObject.tag.Equals("Minion"))
                {
                    Destroy(hit.transform.gameObject);
                }

            }

        }
    }
}
