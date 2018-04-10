using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float current_player_HP = 5;
    public static int player_HP = 5;
    public static float current_player_MP = 50;
    public static int player_MP = 100;

    public bool invincible = false;
    public bool regeningMP = false;

    public float MPRegenDelay = 1f;

    public static int score = 100;
    public Text scoreLine;

    public Text bulletsText;
    public static int maxBulletCount = 20;
    public static int bulletCount = maxBulletCount;
    public static int weaponDamage = 1;

    public static bool magazineEmpty = false;

	public Image reloadAnim;
    public Image HP;
    public Image MP;
    public Text HP_count;
    public Text MP_count;
    public Text MP_text;
    public Text HP_text;

    void Start()
    {
        StartCoroutine(RegenerateMana());
        MP_text.text = "MP";
        HP_text.text = "HP";

    }

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
        HP_count.text = current_player_HP.ToString();      
    }

    void ManaBar()
    {
        MP.fillAmount = current_player_MP / player_MP;
        MP_count.text = current_player_MP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        ManaBar();
        TrackScore();
        IsDead();
        TrackBullets();
        Reload();
		reloadAnim.fillAmount = cur_reload;
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
        if (bulletCount <= 0)
        {
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
		if (magazineEmpty == true && Input.GetKeyDown(KeyCode.R))
		{
			
			StartCoroutine (LoadingReload ());
			StartCoroutine (reloadPistol());

		}
	}

	IEnumerator reloadPistol()
	{		
		yield return new WaitForSeconds(1f);
		magazineEmpty = false;
		bulletCount = maxBulletCount;


	}
	public float cur_reload =0;
	public float s_reload = 1;

	IEnumerator LoadingReload()
	{
		while (cur_reload <= s_reload) {
			cur_reload += 0.1f;		
			yield return new WaitForSeconds (0.08f);
		}
		cur_reload = 0;
	}

    IEnumerator RegenerateMana()
    {
        while (true)
        {
            if (current_player_MP < player_MP)
            {
                current_player_MP += 1;
                yield return new WaitForSeconds(MPRegenDelay);
            }
            else
            {
                yield return null;
            }
        }
    }
}
