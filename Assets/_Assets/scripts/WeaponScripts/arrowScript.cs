using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Minion"))
        {
            /*Destroy(other.gameObject);*/
            other.GetComponent<EnemyScript>().takeDemege(dmg);
            MinionAnimationControllerScript animated = other.GetComponent<MinionAnimationControllerScript>();
            if (animated != null)
            {
                animated.ArrowHit();
            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("InvicibleWall"))
        {
            Destroy(gameObject);
        }

        // if(other.gameObject.tag.Equals("ArcheryTarget")) {
        //     other.gameObject.GetComponent<TargetScript>().AdvanceInAnimation();
        // }
    }

}
