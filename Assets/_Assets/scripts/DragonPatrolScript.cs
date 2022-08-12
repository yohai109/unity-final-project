using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPatrolScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
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
        yield return new WaitForSeconds(5);
        movingFlag = true;
    }
}
