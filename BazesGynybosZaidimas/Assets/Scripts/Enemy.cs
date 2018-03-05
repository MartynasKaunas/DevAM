using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Enemy : MonoBehaviour {
	//To access variables from different scripts variable should be changed to static
    public float enemySpeed = 1;         // How fast enemy is moving
    public float curent_enemy_hp = 10;   //  public float start_hp;
    public int enemy_HP = 10;
    public int scoreValue = 17;
    public int count_deaths_this_enemy;
    public Image HP;
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            curent_enemy_hp -= 1;
            if (curent_enemy_hp <= 0)
            {
                count_deaths_this_enemy ++;
                Player.score += scoreValue;
                //Player.scoreLine.text = "score : " + Player.score; // text tipas negali būti static :(
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "Player")
        {
            Recoil();
        }

    }

    void HealthBar() {
        HP.fillAmount = curent_enemy_hp / enemy_HP;
    }
	
	// Update is called once per frame
	void Update(){
        HealthBar();
		Movement (); 		                                                                    
	}

	public void Movement(){		
		transform.Translate (Vector2.right * Time.deltaTime * enemySpeed);
	}

    public void Recoil(){
        transform.Translate(Vector2.left * Time.deltaTime * 15);
        enemySpeed = 1;
    }

}
