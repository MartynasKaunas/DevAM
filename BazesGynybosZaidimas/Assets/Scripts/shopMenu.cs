using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopMenu : MonoBehaviour
{
    public static bool levelClear = false;
    public GameObject shopMenuUI;
    public GameObject allUI;
    public GameObject healUI;
    public GameObject UpgradeDmgUI;
    public GameObject UpgradeHpUI;
    public GameObject UpgradeAmmoUI;
    public GameObject BuyShotgunUI;
    public GameObject BuyCannonUI;
    public Text weaponDamage;
    public Text scoreCount;
    public Text maxHealth;
    public Text currentHealth;
    public Text maxAmmo;

    public static bool shotgunBought = false;
    public static bool cannonBought = false;

    int temp_currentLevel = 1;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();

        if (levelClear == true)
        {
            Pause();
        }
    }

    public void Resume()
    {
        levelClear = false;
        shopMenuUI.SetActive(false);
        allUI.SetActive(true);
        Time.timeScale = 1f;

    }

    public void Pause()
    {
        if (levelClear == true)
        {
            shopMenuUI.SetActive(true);
            allUI.SetActive(false);
            Time.timeScale = 0f;
            Destroy(GameObject.Find("Projectile(Clone)"));
            healUI.SetActive(true);
            UpgradeDmgUI.SetActive(true);
            UpgradeHpUI.SetActive(true);
            UpgradeAmmoUI.SetActive(true);

            if (shotgunBought == true || cannonBought == true)
            {
                BuyShotgunUI.SetActive(false);
                BuyCannonUI.SetActive(false);
            }
            else BuyShotgunUI.SetActive(true);

            if (cannonBought == true || shotgunBought == true)
            {
                BuyShotgunUI.SetActive(false);
                BuyCannonUI.SetActive(false);
            }
            else BuyCannonUI.SetActive(true);

            DamageText();
            CurrentHealthText();
            MaxHealthText();
            MaxAmmoText();
            ScoreText();

        }
    }

    void checkLevel()  //tikrina ar lygis pereitas
    {

        if (Spawner.level == temp_currentLevel + 1)
        {
            temp_currentLevel = Spawner.level;
            levelClear = true;
        }
    }

    public void BuyShotgun()
    {
        if (Player.score > 100)
        {
            Taikymasis.weaponType = 2;
            Taikymasis.speed = 8;
            shotgunBought = true;
            BuyShotgunUI.SetActive(false);
            Player.score -= 100;
        }
    }

    public void BuyCannon()
    {
        if (Player.score > 100)
        {
            Taikymasis.weaponType = 3;
            Taikymasis.speed = 30;
            cannonBought = true;
            BuyCannonUI.SetActive(false);
            Player.score -= 100;
        }
    }

    public void Heal()
    {
        if (Player.score > 5)
        {
            if (Player.current_player_HP != Player.player_HP)
            {
                Player.current_player_HP += 1;
                healUI.SetActive(false);
                Player.score -= 5;
            }
        }
    }

    public void UpgradeDamage()
    {
        if (Player.score > 15)
        {
            Player.weaponDamage += 1;
            UpgradeDmgUI.SetActive(false);
            Player.score -= 15;
        }

    }

    public void UpgradeHealth()
    {
        if (Player.score > 20)
        {
            Player.player_HP += 1;
            Player.current_player_HP += 1;
            UpgradeHpUI.SetActive(false);
            Player.score -= 20;
        }
    }

    public void UpgradeAmmo()
    {
        if (Player.score > 3)
        {
            Player.maxBulletCount += 1;
            UpgradeAmmoUI.SetActive(false);
            Player.score -= 3;
        }
    }

    void DamageText()
    {
        weaponDamage.text = "Damage: " + Player.weaponDamage;
    }

    void ScoreText()
    {
        scoreCount.text = "Current score: " + Player.score;
    }

    void MaxAmmoText()
    {
        maxAmmo.text = "Max ammo: " + Player.maxBulletCount;
    }

    void MaxHealthText()
    {
        maxHealth.text = "Max health: " + Player.player_HP;
    }

    void CurrentHealthText()
    {
        currentHealth.text = "Current health: " + Player.current_player_HP;
    }
}
