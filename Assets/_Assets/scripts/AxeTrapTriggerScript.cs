using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrapTriggerScript : MonoBehaviour
{
    public Rigidbody[] parts;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Rigidbody part in parts)
        {
            part.useGravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Rigidbody part in parts)
        {
            part.useGravity = true;
        }
    }
}
