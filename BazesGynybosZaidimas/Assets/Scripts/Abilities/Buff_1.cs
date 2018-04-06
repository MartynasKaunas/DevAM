using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff_1 : MonoBehaviour {

    public GameObject buffParticle;
    public GameObject particleSource;

    public int AbilityCost = 30;
    public int BuffDuration = 5;
    public int damageBuffAmount = 10;
    public int speedBuffAmount = 2;
    public int fireRateBuffAmount = 10;
    public int maxBulletBuffAmount = 1000;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            if (Player.current_player_MP >= AbilityCost)
            {
                Player.current_player_MP -= AbilityCost;

                Player.maxBulletCount += maxBulletBuffAmount;
                Player.bulletCount += maxBulletBuffAmount;                
                Player.weaponDamage *= damageBuffAmount;
                Taikymasis.speed *= speedBuffAmount;
                Taikymasis.fireRate /= fireRateBuffAmount;

                Debug.Log("original speed" + Taikymasis.speed);

                Instantiate(buffParticle, particleSource.transform.position, particleSource.transform.rotation);

                StartCoroutine(BuffTimer());
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

        Player.maxBulletCount -= maxBulletBuffAmount;
        Player.bulletCount = Player.maxBulletCount;
        Player.weaponDamage /= damageBuffAmount;
        Taikymasis.speed /= speedBuffAmount;
        Taikymasis.fireRate *= fireRateBuffAmount;

        //Debug.Log("restored speed " + Taikymasis.speed);
        //Debug.Log("restored damage " + Player.weaponDamage);
        //Debug.Log("restored fire rate " + Taikymasis.fireRate);
        //Debug.Log("redtored bulletcount " + Player.bulletCount);

    }
}
