using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonScript : MonoBehaviour
{
    public float speed;
    private bool isDragonFollowing = false;
    private Vector3 target, moveDirection;
    // Start is called before the first frame update
    private float currentSpeed;
    private Animator animator;

    private int level = 0;

    private void Start()
    {
        currentSpeed = speed;
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDragonFollowing)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
            moveDirection = target - transform.position;
            transform.LookAt(target);

            GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
        }
    }

    public void Wake()
    {
        level = 1;
        animator.SetTrigger("WakeTrigger");
        StartCoroutine(DragonStartFollow(7));
    }

    private IEnumerator DragonStartFollow(int seconds)
    {
        speed = 0;
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("WalkTrigger");
        speed = currentSpeed;
        isDragonFollowing = true;
    }

    IEnumerator Stay()
    {
        float oldSpeed = speed;
        speed = 0;
        animator.SetTrigger("WakeTrigger");
        yield return new WaitForSeconds(3);
        animator.SetTrigger("WalkTrigger");
        speed = oldSpeed;
    }

    private void SpeedUp()
    {
        this.speed *= 2;
    }


    private void startRunning()
    {
        animator.SetTrigger("RunTrigger");
        SpeedUp();
    }

    private void runFaster()
    {
        animator.SetTrigger("RunFasterTrigger");
        SpeedUp();
    }

    public void die()
    {
        animator.SetTrigger("DieTrigger");
        speed = 0;
        StartCoroutine(dieWaiting());
    }

    IEnumerator dieWaiting()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("WinningMenuScene");
    }

    public void nextLevel()
    {
        level++;
        if (level == 2)
        {
            startRunning();
        }
        else if (level == 3)
        {
            runFaster();
        }
    }
}
