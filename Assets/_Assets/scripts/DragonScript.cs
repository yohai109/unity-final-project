using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Wake() {
        gameObject.GetComponent<Animator>().SetTrigger("WakeTrigger");
    }
}
