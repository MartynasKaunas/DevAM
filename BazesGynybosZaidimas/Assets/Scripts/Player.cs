using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {
    public float curent_player_hp = 3;
    public int player_HP = 3;
    public Image HP;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Enemy")
        {
            curent_player_hp -= 1;
            if (curent_player_hp == 0)
            {
                
                Destroy(gameObject);
            }
        }

    }
    void HealthBar()
    {
        HP.fillAmount = curent_player_hp / player_HP;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
    }


	
}
