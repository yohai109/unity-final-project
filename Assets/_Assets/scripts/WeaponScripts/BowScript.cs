using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public Rigidbody arrowPrefab;
    public float speed = 10f;
    public Transform notRiggidBodyArrow;
    // Start is called before the first frame update
    void Start()
    {
        arrowPrefab.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody arrow = Instantiate(arrowPrefab, notRiggidBodyArrow.position, notRiggidBodyArrow.rotation, null);
            arrow.gameObject.SetActive(true);
            arrow.AddForce(transform.forward * speed);
        }
    }
}
