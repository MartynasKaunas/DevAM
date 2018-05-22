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
                enemyMove();
                WallUI.SetActive(false);
                
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
           

        }

    }

    public void UpgrageeWall()
    {
        if (Player.score > 50)
        {
            if (WallUI.active)
            {
                Debug.Log(HP);
                HP = HP + 1;
                Debug.Log(HP);
                current_wall_HP = HP;
                Player.score -= 50;
            }
        }


    }

    public void placeWall()
    {
        Debug.Log(Wall.current_wall_HP);
        if (Player.score > 100)
        {
            if (Wall.current_wall_HP <= 0)
            {
                current_wall_HP = HP;
                WallUI.SetActive(true);
                Player.score -= 100;
            }
        }
    }

    public void enemyMove()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Animator e = enemy.GetComponent<Animator>();
            Enemy ee = enemy.GetComponent<Enemy>();

            ee.enemySpeed = 2;
            e.SetFloat("speed", 5);
        }
    }
}