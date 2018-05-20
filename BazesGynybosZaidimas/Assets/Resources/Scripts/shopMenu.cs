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
    public GameObject BuyTrapUI;
    public GameObject BuyWallUI;//siena
    public GameObject BuyWallUpgradeUI;//siena upgrade
    public GameObject CurrentWeaponUI;
	public GameObject UpgradeReloadUI;
	public GameObject ManaRegenSpeedUI;
	public GameObject BuyArUI;
    public Text weaponDamage;
    public Text scoreCount;
    public Text maxHealth;
    public Text currentHealth;
    public Text maxAmmo;

    public AudioClip LevelClear;
    private AudioSource audioSource;

    public bool soundPlayed = false;

    public static bool shotgunBought = false;
    public static bool cannonBought = false;
	public static bool ArBought = false;

    public int currentlyOpen = 0;
    public static int temp_currentLevel = 1;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
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

    void checkLevel()  //tikrina ar lygis pereitas
    {

        if (Spawner.level == temp_currentLevel + 1)
        {
            temp_currentLevel = Spawner.level;
            levelClear = true;
        }
    }

    public void Resume()
    {
        levelClear = false;
        soundPlayed = false;
        shopMenuUI.SetActive(false);
        allUI.SetActive(true);
        Time.timeScale = 1f;

    }

    public void Pause()
    {
        if (levelClear == true)
        {
            if (soundPlayed == false)
            {
                audioSource.PlayOneShot(LevelClear);
                soundPlayed = true;
            }
            shopMenuUI.SetActive(true);
            allUI.SetActive(false);
            Time.timeScale = 0f;
            Destroy(GameObject.Find("Projectile(Clone)"));
            if (currentlyOpen == 0)
                openWeapons(true);
            if (currentlyOpen == 1)
                openCharStuf(true);
            if (currentlyOpen == 2)
                openWallStuf(true);

            DamageText();
            CurrentHealthText();
            MaxHealthText();
            MaxAmmoText();
            ScoreText();
        }
    }

    public void changeCurrentlyOpen(int i)
    {
        currentlyOpen = i;
    }

    public void openCharStuf(bool open)
    {
        if (open)
        {
            openWallStuf(false);
            openWeapons(false);
        }

        

        UpgradeHpUI.SetActive(open);
        healUI.SetActive(open);
		UpgradeReloadUI.SetActive (open);
		ManaRegenSpeedUI.SetActive (open);
    }

    public void openWallStuf(bool open)
    {
        if (open)
        {
            openWeapons(false);
            openCharStuf(false);
        }

        BuyTrapUI.SetActive(open);
        BuyWallUI.SetActive(open);
        BuyWallUpgradeUI.SetActive(open);
    }

    public void openWeapons(bool open)
    {
        CurrentWeaponUI.SetActive(open);

        if (open)
        {
            openCharStuf(false);
            openWallStuf(false);
        }

        UpgradeDmgUI.SetActive(open);
        UpgradeAmmoUI.SetActive(open);

		if (shotgunBought == true || cannonBought == true || ArBought == true)
        {
            BuyShotgunUI.SetActive(false);
            BuyCannonUI.SetActive(false);
			BuyArUI.SetActive (false);
        }
        else BuyShotgunUI.SetActive(open);

        if (cannonBought == true || shotgunBought == true)
        {
            BuyShotgunUI.SetActive(false);
            BuyCannonUI.SetActive(false);
			BuyArUI.SetActive (false);
        }
        else BuyCannonUI.SetActive(open);

		if (cannonBought == true || shotgunBought == true || ArBought == true)
		{
			BuyShotgunUI.SetActive(false);
			BuyCannonUI.SetActive(false);
			BuyArUI.SetActive (false);
		}
		else BuyArUI.SetActive(open);


    }

    public void BuyShotgun()
    {
        if (Player.score > 100)
        {
            Taikymasis.weaponType = 2;
            if (Buff_1.BuffActive == true)
            {
                Buff_1.originalSpeed = 8;
            }
            else
            {
                Taikymasis.speed = 8;
            }
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
            if (Buff_1.BuffActive == true)
            {
                Buff_1.originalSpeed = 30;
            }
            else
            {
                Taikymasis.speed = 30;
            }
            cannonBought = true;
            BuyCannonUI.SetActive(false);
            Player.score -= 100;
        }
    }

	public void BuyAR()
	{
		if (Player.score > 100)
		{
			Taikymasis.weaponType = 4;
            if (Buff_1.BuffActive == true)
            {
                Buff_1.originalSpeed = 30;
            }
            else
            {
                Taikymasis.speed = 30;
            }          

			ArBought = true;
			BuyArUI.SetActive(false);
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
        if (Player.score > 50)
        {
            if (Buff_1.BuffActive == true)
            {
                Buff_1.originalDamage++;
                Player.weaponDamage += 1;
            }
            else
            {
                Player.weaponDamage += 1;
            }
            UpgradeDmgUI.SetActive(false);
            Player.score -= 50;
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

	public void ReloadTimeUpgrade()
	{
		if (Player.score > 25 && Player.reloadWaitFor >= 0.2) {
			Player.s_reload -= 0.2f;
			Player.reloadWaitFor -= 0.2f;
			Player.score -= 25;
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

	public void UpgradeManaRegen()
	{
		if (Player.score > 50 && Player.MPRegenDelay >= 0.1) {
			Player.MPRegenDelay -= 0.1f;
			Player.score -= 50;

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
