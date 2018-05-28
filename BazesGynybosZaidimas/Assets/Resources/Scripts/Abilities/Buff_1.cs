using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff_1 : MonoBehaviour {

    public GameObject buffParticle;
    public GameObject particleSource;

    public GameObject ready;
    public GameObject down;
    public GameObject Q;
    public GameObject background;

    public int AbilityCost = 50;
    public int BuffDuration = 7;

    public int damageBuffAmount = 10;
    public int speedBuffAmount = 2;
    public int fireRateBuffAmount = 10;
    public int maxBulletBuffAmount = 1000;

    public static int originalDamage;
    public static float originalSpeed;
    public float originalFireRate;
    public static int originalMaxBulletCount;

    public static bool BuffActive = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.current_player_MP >= 50)
        {
            ready.SetActive(true);
            down.SetActive(false);
            Q.SetActive(true);
            background.SetActive(true);
        }
        else
        {
            Q.SetActive(false);
            ready.SetActive(false);
            down.SetActive(false);
            background.SetActive(false);
        }
        if (BuffActive)
        {
            ready.SetActive(false);
            down.SetActive(true);
        }
        if (Input.GetButtonDown("Ability1"))
        {
            if (Player.current_player_MP >= AbilityCost)
            {
                if (BuffActive == false)
                {
                    BuffActive = true;

                    originalDamage = Player.weaponDamage;
                    originalSpeed = Taikymasis.speed;
                    originalFireRate = Taikymasis.fireRate;
                    originalMaxBulletCount = Player.maxBulletCount;

                    Player.current_player_MP -= AbilityCost;

                    Player.maxBulletCount += maxBulletBuffAmount;
                    Player.bulletCount += maxBulletBuffAmount;
                    Player.weaponDamage *= damageBuffAmount;
                    Taikymasis.speed *= speedBuffAmount;
                    Taikymasis.fireRate /= fireRateBuffAmount;

                    Instantiate(buffParticle, particleSource.transform.position, particleSource.transform.rotation);

                    StartCoroutine(BuffTimer());
                }
            }
        }
    }

    // Now run a timer
    IEnumerator BuffTimer()
    {
        yield return new WaitForSeconds(BuffDuration);
        playerBuffUndo();
    }

    //Now return the value back to original
    void playerBuffUndo()
    {
        //Debug.Log("original speed " + Taikymasis.speed);
        //Debug.Log("original damage " + Player.weaponDamage);
        //Debug.Log("original fire rate " + Taikymasis.fireRate);
        //Debug.Log("original bulletcount " + Player.bulletCount);

        Player.maxBulletCount = originalMaxBulletCount;
        Player.bulletCount = Player.maxBulletCount;
        Player.weaponDamage = originalDamage;
        Taikymasis.speed = originalSpeed;
        Taikymasis.fireRate = originalFireRate;

        BuffActive = false;

        /*
        Player.maxBulletCount -= maxBulletBuffAmount;
        Player.bulletCount = Player.maxBulletCount;
        Player.weaponDamage /= damageBuffAmount;
        Taikymasis.speed /= speedBuffAmount;
        Taikymasis.fireRate *= fireRateBuffAmount;
        */

        //Debug.Log("restored speed " + Taikymasis.speed);
        //Debug.Log("restored damage " + Player.weaponDamage);
        //Debug.Log("restored fire rate " + Taikymasis.fireRate);
        //Debug.Log("restored bulletcount " + Player.bulletCount);

    }
}
