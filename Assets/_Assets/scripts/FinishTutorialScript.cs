using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishTutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("ahalan");
        if (other.gameObject.tag.Equals("Player")) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
