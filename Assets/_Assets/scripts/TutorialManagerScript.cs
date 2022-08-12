using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManagerScript : MonoBehaviour
{
    public int patrolSpeed;

    public GameObject invisibleWall_Bow;
    public GameObject invisibleWall_Sword;

    public GameObject playerBow;
    public GameObject playerSword;


    // Start is called before the first frame update
    void Start()
    {
        playerBow.SetActive(false);
        playerSword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTookBow() {
        GameObject bow = GameObject.FindWithTag("Bow");
        Destroy(bow);
        Destroy(invisibleWall_Bow);
        playerBow.SetActive(true);
        playerSword.SetActive(false);
    }
    
    public void PlayerTookSword() {
        GameObject sword = GameObject.FindWithTag("Sword");
        Destroy(sword);
        Destroy(invisibleWall_Sword);
        playerSword.SetActive(true);
        playerBow.SetActive(false);
    }
}
