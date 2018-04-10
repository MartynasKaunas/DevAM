using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int destroyTime = 2;
    void Update()
    {
        
        Destroy(gameObject, destroyTime);

        Physics2D.IgnoreLayerCollision(8, 9);
    }
}
