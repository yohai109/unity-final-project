using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("hit");
            RaycastHit hit;
            int rayLength = 50;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.forward, out hit, rayLength))
            {
                if (hit.collider.gameObject.tag.Equals("Minion"))
                {
                    Destroy(hit.transform.gameObject);
                }

            }

        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Minion"))
        {
            Destroy(other.gameObject);
            *//*Destroy(gameObject);*//*
        }
    }*/
}
