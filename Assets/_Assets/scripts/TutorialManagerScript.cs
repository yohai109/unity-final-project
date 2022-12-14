using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManagerScript : MonoBehaviour
{
    public int patrolSpeed;

    public GameObject invisibleWall_Bow;
    public GameObject invisibleWall_Sword;
    public GameObject invisibleWall_Target;
    public GameObject invisibleWall_Dragon;

    public GameObject playerBow;
    public GameObject playerSword;

    public GameObject dragon;

    public GameObject target;
    private int animationStage;

    private bool isDragonActive = false;


    // Start is called before the first frame update
    void Start()
    {
        playerBow.SetActive(false);
        playerSword.SetActive(false);

        dragon.SetActive(false);

        animationStage = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(isDragonActive) {
            if(GameObject.FindGameObjectWithTag("Minion") == null) {
                Destroy(invisibleWall_Dragon);
            }
        }
    }

    public void PlayerTookBow() {
        GameObject bow = GameObject.FindWithTag("Bow");
        Destroy(bow);
        Destroy(invisibleWall_Bow);
        playerBow.SetActive(true);
        playerSword.SetActive(false);

        target.GetComponent<Animator>().SetTrigger("TargetUp");
    }
    
    public void PlayerTookSword() {
        GameObject sword = GameObject.FindWithTag("Sword");
        Destroy(sword);
        Destroy(invisibleWall_Sword);
        dragon.SetActive(true);
        playerSword.SetActive(true);
        playerBow.SetActive(false);

        isDragonActive = true;
    }

    public void TargetDestroyed() {
        Destroy(invisibleWall_Target);
    }
}
