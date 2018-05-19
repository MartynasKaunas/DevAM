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

    public static float MPRegenDelay = 1f;

    public static int score = 300;
    public Text scoreLine;

    public Text bulletsText;
    public static int maxBulletCount = 20;
    public static int bulletCount = maxBulletCount;
    public static int weaponDamage = 1;

    public static bool magazineEmpty = false;

    public GameObject smokeParticle;
    public GameObject smokeOrigin1;
    public GameObject smokeOrigin2;
    public static bool smoke1 = false;
    public static bool smoke2 = false;

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
        SmokeParticles();
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
        bulletsText.text = "Bullets: " + bulletCount;
        if (bulletCount <= 0)
        {
            magazineEmpty = true;
            bulletsText.text = "press R to reload";
        }

    }

    public void TrackScore()
    {
        scoreLine.text = "score : " + score;
    }

    public void Reload()
    {
        if (magazineEmpty == true && Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(LoadingReload());
            StartCoroutine(reloadPistol());

        }
    }

    IEnumerator reloadPistol()
    {
        yield return new WaitForSeconds(reloadWaitFor);
        magazineEmpty = false;
        bulletCount = maxBulletCount;


    }
    public float cur_reload = 0;
    public static float s_reload = 1;

    IEnumerator LoadingReload()
    {
        while (cur_reload <= s_reload)
        {
            cur_reload += 0.1f;
            yield return new WaitForSeconds(0.08f);
        }
        cur_reload = 0;
    }
    public static float reloadWaitFor = 1f;

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

    public void SmokeParticles()
    {
        if (Player.current_player_HP <= Player.player_HP * 2 / 3 && smoke1 == false)
        {
            Instantiate(smokeParticle, smokeOrigin1.transform.position, smokeOrigin1.transform.rotation);
            smoke1 = true;
        }
        if (current_player_HP <= player_HP * 1 / 3 && smoke2 == false)
        {
            Instantiate(smokeParticle, smokeOrigin2.transform.position, smokeOrigin2.transform.rotation);
            smoke2 = true;
        }
    }
}
