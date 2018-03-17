using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool isSpawning = false;
    public float minTime = 3.0f;
    public float maxTime = 8.0f;
    //public GameObject[] enemies;  // Array of enemy prefabs.
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    IEnumerator SpawnObject(float seconds)
    {
        Debug.Log("Waiting for " + seconds + " seconds");

        yield return new WaitForSeconds(seconds);
      
        Vector3 V;
        V = new Vector3(transform.position.x, Random.Range(-3.0f, 2.5f));
        //   Random randomSp = new Random();

        int i = Random.Range(1,3);
        Debug.Log("iiiiiiiiiiiiiiiiii" + i + " seconds");
        switch (i)
        {
            case 1:
               Instantiate(enemyPrefab1, V, transform.rotation);
                break;
            case 2:
                Instantiate(enemyPrefab, V, transform.rotation);
                break;
        }
        
        

    
        //We've spawned, so now we could start another spawn     
        isSpawning = false;
    }

    void Update()
    {
        //We only want to spawn one at a time, so make sure we're not already making that call
        if (!isSpawning)
        {
            isSpawning = true; //Yep, we're going to spawn
            StartCoroutine(SpawnObject(Random.Range(minTime, maxTime)));

        }
    }


}
