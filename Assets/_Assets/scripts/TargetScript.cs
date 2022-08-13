using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    private int animationStage;

    // Start is called before the first frame update
    void Start()
    {
        animationStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Arrow"))
        {
            Destroy(other.gameObject);
            AdvanceInAnimation();
        }
    }

    public void AdvanceInAnimation() {
        animationStage++;

        switch(animationStage) {
            case 1: gameObject.GetComponent<Animator>().SetTrigger("Side2Side1"); break;
            case 2: gameObject.GetComponent<Animator>().SetTrigger("Side2Side2"); break;
            case 3: gameObject.GetComponent<Animator>().SetTrigger("Side2Side3"); break;
            case 4: gameObject.GetComponent<Animator>().SetTrigger("Side2Side4"); break;
            case 5: gameObject.GetComponent<Animator>().SetTrigger("Swirly"); break;
            case 6:
                gameObject.GetComponent<Animator>().SetTrigger("Exit");
                Destroy(GameObject.Find("Cylinder.003"));
                GameObject[] voronoyArray = GameObject.FindGameObjectsWithTag("VoronoyObject");

                foreach (GameObject voronoy in voronoyArray) {
                    Rigidbody voronoyRigidBody = voronoy.AddComponent<Rigidbody>();
                    voronoyRigidBody.mass = 2;
                }

                GameObject.FindWithTag("Manager").GetComponent<TutorialManagerScript>().TargetDestroyed();
                break;
        }
    }
}
