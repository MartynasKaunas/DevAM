using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {
    public float current_player_hp = 3;
    public int player_HP = 3;
    public bool invincible = false;
    public static int score = 0;
    public Text scoreLine;
    

    public Image HP;
    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && invincible == false)
        {
            current_player_hp -= 1;

            invincible = true;
            yield return new WaitForSeconds(1);
            invincible = false;
        }

    }
    void HealthBar()
    {
        HP.fillAmount = current_player_hp / player_HP;
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

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void IsDead()
    {
        if (current_player_hp == 0)
        {
            FindObjectOfType<Ending>().EndMePlz();
            Destroy(gameObject);
        }
    }
    public void TrackScore()
    {
        scoreLine.text = "score : " + score;
    }
}
