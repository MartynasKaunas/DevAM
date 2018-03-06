using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int destroyTime = 1;
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
