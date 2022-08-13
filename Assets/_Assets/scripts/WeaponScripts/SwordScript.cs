using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int range = 50;
    public Transform player;
    public int dmg = 3;
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
                    hit.collider.gameObject.GetComponent<EnemyScript>().takeDemege(dmg);
                    MinionAnimationControllerScript animated = hit.collider.gameObject.GetComponent<MinionAnimationControllerScript>();
                    if (animated != null)
                    {
                        animated.ArrowHit();
                    }
                }

            }

        }
    }
}
