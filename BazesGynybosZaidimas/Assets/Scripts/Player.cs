using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {
    public static float current_player_HP = 3;
    public static int player_HP = 3;
    public bool invincible = false;
    public static int score = 100;
    public Text scoreLine;

	public Text bulletsText;
    public static int maxBulletCount = 20;
	public static int bulletCount = maxBulletCount;
    public static int weaponDamage = 1;

    public static bool magazineEmpty = false;

    public Image HP;
    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && invincible == false)
        {
            current_player_HP -= 1;

            invincible = true;
            yield return new WaitForSeconds(1);
            invincible = false;
        }

    }
    void HealthBar()
    {
        HP.fillAmount = current_player_HP / player_HP;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        TrackScore();
        IsDead();
		TrackBullets();
		Reload();
    }

    void IsDead()
    {
        if (current_player_HP == 0)
        {
            FindObjectOfType<Ending>().EndMePlz();
            Destroy(gameObject);
        }
    }
	public void TrackBullets()
	{
		if (bulletCount <= 0) {
			magazineEmpty = true;
		}
		bulletsText.text = "BulletsLeft: " + bulletCount;
	}
    public void TrackScore()
    {
        scoreLine.text = "score : " + score;
    }
	public void Reload()
	{
		if (magazineEmpty == true && Input.GetKeyDown(KeyCode.R)) {
			magazineEmpty = false;
			bulletCount = maxBulletCount;
		}
	}


}
