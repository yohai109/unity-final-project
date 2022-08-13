using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other) {
         if (other.gameObject.tag == "Bow") {
            GameObject.FindWithTag("Manager").GetComponent<TutorialManagerScript>().PlayerTookBow();
         }
         if (other.gameObject.tag == "Sword") {
            GameObject.FindWithTag("Manager").GetComponent<TutorialManagerScript>().PlayerTookSword();
         } 
    }   
}
