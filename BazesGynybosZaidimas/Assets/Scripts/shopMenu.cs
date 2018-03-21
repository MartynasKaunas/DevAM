using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopMenu : MonoBehaviour {
	public bool levelClear = false;
	public GameObject shopMenuUI;
	public GameObject allUI;
	public GameObject healUI;
	public GameObject UpgradeUI;
	public Text weaponDamage;


	int temp_currentLevel = 1;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
		checkLevel ();
		if (levelClear == true) {
		//	shopMenuUI.SetActive (true);
			Pause ();
		}
	}
	public void Resume()
	{
		    levelClear = false;
			shopMenuUI.SetActive (false);
		    allUI.SetActive (true);
			Time.timeScale = 1f;
	
	}
	public void Pause()
	{
		if (levelClear == true) {
			shopMenuUI.SetActive(true);
			allUI.SetActive (false);
			Time.timeScale = 0f;
			Destroy(GameObject.Find ("Projectile(Clone)"));
			healUI.SetActive (true);
			UpgradeUI.SetActive (true);
			DamageText ();

		}
	}
	void checkLevel()//tikrina ar lygis pereitas
	{
		
		if (Spawner.level == temp_currentLevel+1) {
			temp_currentLevel = Spawner.level;
			levelClear = true;
		}
	}
	public void Heal()
	{
		if(Player.current_player_hp != 3)
		Player.current_player_hp = 3;
		healUI.SetActive (false);
	}
	public void UpgradeWeapon()
	{
		Enemy.weaponDamage += 1;
		UpgradeUI.SetActive (false);

	}
	void DamageText()
	{
		weaponDamage.text = "Damage: " + Enemy.weaponDamage;
	}


}
