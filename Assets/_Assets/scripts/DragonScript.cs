using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public float speed;
    private bool isDragonFollowing = false;
    private Vector3 target, moveDirection;
    // Start is called before the first frame update
    private float currentSpeed;

    private void Start() {
        currentSpeed = speed;
    }

    private void Update() {
        if (isDragonFollowing) {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
            moveDirection = target - transform.position;
            transform.LookAt(target);
            // if (moveDirection.magnitude < 1)
            // {
            //     StartCoroutine(Stay());
            // }

            GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
        }
    }

    public void Wake() {
        gameObject.GetComponent<Animator>().SetTrigger("WakeTrigger");
        StartCoroutine(DragonStartFollow(7));
    }

    private IEnumerator DragonStartFollow(int seconds) {
        speed = 0;
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<Animator>().SetTrigger("WalkTrigger");
        speed = currentSpeed;
        isDragonFollowing = true;
    }

    IEnumerator Stay()
    {
        float oldSpeed = speed;
        speed = 0;
        gameObject.GetComponent<Animator>().SetTrigger("WakeTrigger");
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Animator>().SetTrigger("WalkTrigger");
        speed = oldSpeed;
    }

    private void SpeedUp() {
        this.speed *= 2;
    }

}
