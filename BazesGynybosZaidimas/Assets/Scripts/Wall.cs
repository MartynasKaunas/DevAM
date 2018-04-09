using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public  float current_HP = 3;
    public  int HP = 3;
    public Image HP1;

    void Start()
    {
    }
    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")// && invincible == false)
        {
            current_HP -= 1;

           // invincible = true;
            yield return new WaitForSeconds(1);
          //  invincible = false;
        }
        
    }
    void HealthBar()
    {
        HP1.fillAmount = current_HP / HP;
       // HP_count.text = current_HP.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        HealthBar();
        IsDead();
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    void IsDead()
    {
        if (current_HP == 0)
        {
            Destroy(gameObject);
        }
    }
}