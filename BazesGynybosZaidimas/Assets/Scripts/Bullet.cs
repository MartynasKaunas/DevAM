using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int destroyTime = 2;
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
