using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinionScript : MonoBehaviour
{
    int count = 1;
    public int MAX = 30;
    public Transform player;
    public Transform minionToDuplicate;
    public int minRadius;
    void Start()
    {
        if (count >= MAX)
        {
            count = 1;
        }
        while (count <= MAX)
        {
            float x;
            float z;
            do
            {
                x = getRandNum(700f, 770f);
                z = getRandNum(150f, 300f);
            } while (!isNewPosOK(x, z));
            Vector3 pos = new Vector3(x, transform.position.y, z);
            Instantiate(minionToDuplicate, pos, transform.rotation, transform);
            count++;
        }
    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            SceneManager.LoadScene("WinningMenuScene");
        }
    }

    float getRandNum(float min, float max)
    {
        float last = -1;
        float newNumber;
        do
        {
            newNumber = Random.Range(min, max);
        } while (newNumber == last);
        return newNumber;
    }

    bool isNewPosOK(float newX, float newZ)
    {
        bool isXOk = player.position.x + minRadius > newX || player.position.x - minRadius < newX;
        bool isZOk = player.position.z + minRadius > newZ || player.position.z - minRadius < newZ;
        return isXOk && isZOk;
    }
}
