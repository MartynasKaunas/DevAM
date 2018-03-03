using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Enemy : MonoBehaviour {
	//Too access variables from different scripts variable should be changed to static
     public int enemySpeed = 1; // How fast enemy is moving
    public float curent_enemy_hp=10;
  //  public float start_hp;
    public int enemy_HP = 10;
    public int count_deths_this_enemy;
    public Image HP;
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            curent_enemy_hp -= 1;
            if (curent_enemy_hp <= 0)
            {
                count_deths_this_enemy ++;
                Destroy(gameObject);
            }
        }

    }
    void HealthBar() {
        HP.fillAmount = curent_enemy_hp / enemy_HP;
    }
	


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        HealthBar();
		Movement (); 
		                                                                    
	}

	public void Movement(){
		
		transform.Translate (Vector2.right * Time.deltaTime * enemySpeed);

	}
	// To Do: EnemyHealth is reduced depending on what type of gun he got shot with.
	public void Health()
	{

	}

}
