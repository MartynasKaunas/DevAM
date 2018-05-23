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
    public static float minTime = 3.0f;
    public static float maxTime = 7.0f;
    public GameObject enemyPrefab;    //lėtas

    public static float slowSpeedBuff = 0;
    public static int slowHPBuff = 0;

    public GameObject enemyPrefab1;   //greitas

    public static float fastSpeedBuff = 0;
    public static int fastHPBuff = 0;

    public GameObject enemyPrefab2;   //skraido

    public static float flyingSpeedBuff = 0;
    public static int flyingHPBuff = 0;

    public GameObject enemyPrefabBoss;   //Bossas

    public static int BossHPBuff = 0;

    public AudioClip levelMusic1;
    public AudioClip levelMusic2;
    public AudioClip levelMusic3;
    private AudioSource audioSource;
    public static int trackMusic = 1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(levelMusic1);
    }

    IEnumerator SpawnObject(float seconds)
    {
        //    Debug.Log("Waiting for " + seconds + " seconds");

        yield return new WaitForSeconds(seconds);


        Vector3 V = new Vector3(transform.position.x, Random.Range(-3.0f, 2.0f));
        Vector3 V_flaying = new Vector3(transform.position.x, Random.Range(2.0f, 5f));
        //   Random randomSp = new Random();

        int i = Random.Range(1, 4);//parenka prieša
                                   //     Debug.Log("iiiiiiiiiiiiiiiiii" + i + " seconds");//test

        if (level % 10 == 0)
        {
            Vector3 V_Boss = new Vector3(-12, 1, 0);
            GameObject enemyBoss = Instantiate(enemyPrefabBoss, V_Boss, transform.rotation);
            BossAbility B = enemyBoss.GetComponent<BossAbility>();
            B.enemy_HP += BossHPBuff * level / 2;
            B.curent_enemy_hp += BossHPBuff * level / 2;
            leftToSpawn = 0;//one less enemy left
            currentlyAlive++;
        }
        else
        {
            switch (i)
            {
                case 1:
                    GameObject enemySlow = (GameObject)Instantiate(enemyPrefab, V, transform.rotation);
                    Enemy e1 = enemySlow.GetComponent<Enemy>();
                    e1.enemySpeed += slowSpeedBuff;
                    e1.enemy_HP += slowHPBuff;
                    e1.curent_enemy_hp += slowHPBuff;

                    break;
                case 2:
                    GameObject enemyFast = Instantiate(enemyPrefab1, V, transform.rotation);
                    Enemy e2 = enemyFast.GetComponent<Enemy>();
                    e2.enemySpeed += fastSpeedBuff;
                    e2.enemy_HP += fastHPBuff;
                    e2.curent_enemy_hp += fastHPBuff;
                    break;
                case 3:
                    GameObject enemyFlying = Instantiate(enemyPrefab2, V_flaying, transform.rotation);
                    Enemy e3 = enemyFlying.GetComponent<Enemy>();
                    e3.enemySpeed += flyingSpeedBuff;
                    e3.enemy_HP += flyingHPBuff;
                    e3.curent_enemy_hp += flyingHPBuff;
                    break;
            }

            leftToSpawn--;//one less enemy left
            currentlyAlive++;
            //We've spawned, so now we could start another spawn     
        }
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
        if (levelLine != null)
        {
            TrackLevel();
        }

        //Debug.Log("lts " +leftToSpawn + " ca " + currentlyAlive);
        //Debug.Log(trackMusic);

        //For testing only
        if (Input.GetKeyDown("l"))
            LevelUpSpawner();
        if (Input.GetKeyDown("k"))
            Player.score += 50;
        if (shopMenu.levelClear) audioSource.Stop();
    }

    public void TrackLevel()
    {
        levelLine.text = "Level " + level;
        leftForLevel.text = "Enemies left: " + leftToSpawn;
    }

    public void LevelUpSpawner()
    {
        leftToSpawn = (Random.Range(1, 6) + level++ * 3);
        if (minTime > 0.03f)
        {
            minTime = minTime * 0.8f;
            maxTime = maxTime * 0.8f;
        }

        slowHPBuff += 2;
        if (slowSpeedBuff < 10f)
        {
            slowSpeedBuff += 1f;
        }
        fastHPBuff += 1;
        if (fastSpeedBuff < 20f)
        {
            fastSpeedBuff += 1.5f;
        }
        flyingHPBuff += 2;
        if (flyingSpeedBuff < 15f)
        {
            flyingSpeedBuff += 0.5f;
        }
        BossHPBuff += 100;
    }

    public void PlayMusic()
    {
        audioSource.Stop();
        trackMusic++;
        if (trackMusic > 3)
        {
            trackMusic = 1;
            audioSource.PlayOneShot(levelMusic1);
        }
        else if (trackMusic == 1) { audioSource.PlayOneShot(levelMusic1); }
        else if (trackMusic == 2) { audioSource.PlayOneShot(levelMusic2); }
        else if (trackMusic == 3) { audioSource.PlayOneShot(levelMusic3); }
    }
}