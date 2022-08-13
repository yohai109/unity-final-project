using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPatrolScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    public float rotationSpeed;
    int currentWayPoint;
    Vector3 target,
        moveDirection;
    private bool movingFlag = true;


    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindWithTag("Manager").GetComponent<TutorialManagerScript>().patrolSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        target = waypoints[currentWayPoint].position;

        moveDirection = target - transform.position;
        // Quaternion toRotaion = Quaternion.LookRotation(target, Vector3.up);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotaion, rotationSpeed * Time.deltaTime);
        transform.LookAt(target);
        if (moveDirection.magnitude < 1 && movingFlag)
        {
            currentWayPoint = (currentWayPoint + 1) % waypoints.Length;
            StartCoroutine(Stay());    
        }
    
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;

    }

    IEnumerator Stay()
    {
        movingFlag = false;
        GetComponent<Animator>().SetTrigger("Idle");
        float tempSpeed = speed;
        speed = 0;
        //GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        yield return new WaitForSeconds(5);
        speed = tempSpeed;
        GetComponent<Animator>().SetTrigger("Walk");
        movingFlag = true;
    }
}
