using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool invincible = false;
    public static float current_wall_HP = 3;
    public static int HP = 3;
    public Image HP1;
    public GameObject WallUI;//siena isiungimui
                             // public Transform  prefab;

    void Start()
    {

    }

    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && invincible == false)
        {
            current_wall_HP -= 1;

            invincible = true;
            yield return new WaitForSeconds(1);
            invincible = false;
            if (current_wall_HP <= 0)
            {
                invincible = false;
                WallUI.SetActive(false);
                current_wall_HP = HP;
            }
        }

    }

    void HealthBar()
    {
        HP1.fillAmount = current_wall_HP / HP;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(HP);
        HealthBar();
        //   IsDead();
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    void IsDead()
    {
        if (current_wall_HP <= 0)
        {
            invincible = false;
            WallUI.SetActive(false);
            // current_wall_HP = HP;
        }

    }

    public void UpgrageeWall()
    {
        if (Player.score > 100)
        {
            // Wall.placeWall();

            //  current_wall_HP += 1;
            Debug.Log(HP);
            HP = HP + 1;
            Debug.Log(HP);
            current_wall_HP = HP;
            Player.score -= 100;
        }


    }

    public void placeWall()
    {
        if (Player.score > 100)
        {
            // Wall.placeWall();

            current_wall_HP = HP;
            WallUI.SetActive(true);
            Player.score -= 100;
            //Instantiate(prefab, new Vector3(6, -2, 0), Quaternion.identity);
        }


    }
}