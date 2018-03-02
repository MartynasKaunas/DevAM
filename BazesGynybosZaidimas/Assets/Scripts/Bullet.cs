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

    //To do
    //Kodo gabaliukas, padarantis, kad kulka žalotų tikriausiai turėtų būti čia
    //Kažkas maždaug if(collision = priešas) priešas.removehealth

}
