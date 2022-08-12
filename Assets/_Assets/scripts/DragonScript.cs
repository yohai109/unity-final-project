using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DragonScript : MonoBehaviour
{
    public float speed;
    private bool isDragonFollowing = false;
    // Start is called before the first frame update
    private float currentSpeed;
    private Animator animator;
    public Camera cutSceneCamera;
    public Camera mainCamera;

    private int level = 0;

    private Transform player = null;
    private NavMeshAgent agent;

    private void Start()
    {
        /*cutSceneCamera.enabled = false;*/
        switchCamera(false);
        currentSpeed = speed;
        animator = gameObject.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (isDragonFollowing)
        {
            agent.SetDestination(player.position);
            agent.speed = speed;
        }
    }

    public void Wake()
    {
        level = 1;
        animator.SetTrigger("WakeTrigger");
        /*cutSceneCamera.enabled = true;*/
        switchCamera(true);
        StartCoroutine(DragonStartFollow(7));
    }

    private IEnumerator DragonStartFollow(int seconds)
    {
        speed = 0;
        yield return new WaitForSeconds(seconds);
        /*cutSceneCamera.enabled = false;*/
        switchCamera(false);
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
        SceneManager.LoadScene("FinalBossLevel");
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

    private void switchCamera(bool isCutScene)
    {
        cutSceneCamera.enabled = isCutScene;
        /*mainCamera.enabled = !isCutScene;*/
    }
}
