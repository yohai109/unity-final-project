using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    static int count = 1;
    public int MAX = 30;
    public Transform player;
    public int minRadius;
    void Start()
    {
        while (count <= 30)
        {
            float x;
            float z;
            do
            {
                x = getRandNum(660f, 800f);
                z = getRandNum(130f, 330f);
            } while (!isNewPosOK(x, z));
            Vector3 pos = new Vector3(x, transform.position.y, z);
            Instantiate(gameObject, pos, transform.rotation, null);
            count++;
        }
    }

    void Update()
    {

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
