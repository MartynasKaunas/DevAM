using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
	public static int level = 1;
    public Text levelLine;
    public static int leftToSpawn = 0;
    public static int currentlyAlive = 3;   //pradžioje yra trys gyvi, kai juos ištrinsim reiks pakeisti į 0
    public Text leftForLevel;
    bool isSpawning = false;
    public float minTime = 3.0f;
    public float maxTime = 8.0f;
    public GameObject enemyPrefab;    //lėtas
    public GameObject enemyPrefab1;   //greitas
    public GameObject enemyPrefab2;   //skraido
    IEnumerator SpawnObject(float seconds)
    {
        Debug.Log("Waiting for " + seconds + " seconds");

        yield return new WaitForSeconds(seconds);


        Vector3 V = new Vector3(transform.position.x, Random.Range(-3.0f, 2.5f));
        Vector3 V_flaying = new Vector3(transform.position.x, Random.Range(2.5f, 5f));
        //   Random randomSp = new Random();

        int i = Random.Range(1,4);//parenka prieša
        Debug.Log("iiiiiiiiiiiiiiiiii" + i + " seconds");//test
        switch (i)
        {
            case 1:
               Instantiate(enemyPrefab, V, transform.rotation);
                break;
            case 2:
                Instantiate(enemyPrefab1, V, transform.rotation);
                break;
            case 3:
                Instantiate(enemyPrefab2,V_flaying , transform.rotation);
                break;
        }



        leftToSpawn--;//one less enemy left
        currentlyAlive++;
        //We've spawned, so now we could start another spawn     
        isSpawning = false;
        
    }

    void Update()
    {
        //We only want to spawn one at a time, so make sure we're not already making that call
        if (!isSpawning && leftToSpawn > 0)
        {
            isSpawning = true; //Yep, we're going to spawn
            StartCoroutine(SpawnObject(Random.Range(minTime, maxTime)));
            
        }
        TrackLevel();

        //For tessting only
        if (Input.GetKey("l"))
            LevelUpSpawner();
    }

    public void TrackLevel()
    {
        levelLine.text = "Level " + level;
        leftForLevel.text = "Enemies left: " + leftToSpawn;
    }

    public void LevelUpSpawner()
    {
        leftToSpawn = 2 + level++;
        minTime = minTime * 0.9f;
        maxTime = maxTime * 0.9f;
    }
}
