using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Text endReport;
    public static bool GameOver = false;
    public AudioClip GameOverMusic;
    public AudioSource SpawnerAudioSource;
    private AudioSource audioSource;
	public Text highScoree;
    public int previousHighScore;

    // Use this for initialization
    void Start()
    {
        previousHighScore = PlayerPrefs.GetInt("HighScore");
        highScoree.text = "HighScore: " + PlayerPrefs.GetInt ("HighScore", 0).ToString ();
        audioSource = GetComponent<AudioSource>();
        endReport.text = "";
		highScoree.enabled = false;
    }

    public void EndMePlz()
    {
        SpawnerAudioSource.Stop();
        audioSource.PlayOneShot(GameOverMusic);
        endReport.text = "GAME OVER" /*ゲーム　オーワ"*/ + System.Environment.NewLine + " You shot " + Enemy.count_deaths_this_enemy + " enemies and gathered " + Player.score + " points";
        GameOver = true;
        //Debug.Log(previousHighScore);
        if (Player.score > previousHighScore) highScoree.text = "New high score!";
		highScoree.enabled = true;
    }
	public void setScore()
	{
		if ((Player.score > PlayerPrefs.GetInt ("HighScore", 0)) && GameOver == true) {
			PlayerPrefs.SetInt ("HighScore", Player.score);
			highScoree.enabled = true;
		}
	}
    public void Freeze()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

    }

    public void NextLevel()
    {
        Freeze();
        FindObjectOfType<Spawner>().LevelUpSpawner();
    }

    void Update()
    {
		setScore ();
        if (Input.GetKeyDown("escape"))
        {
            if (GameOver == true)
            {

                //iš naujo pradedant žaidimą reikia visus statsus gražint į pradines reikšmes, gal yra kažkoks lengvesnis būdas

                Player.player_HP = 5;
                Player.current_player_HP = 5;
                Player.current_player_MP = 50;
                Player.player_MP = 100;
                Player.maxBulletCount = 20;
                Player.bulletCount = 20;
                Player.score = 0;
                Player.weaponDamage = 1;
                Player.MPRegenDelay = 1f;
                Player.reloadWaitFor = 1f;
                Taikymasis.weaponType = 1;
                Taikymasis.speed = 45;

                endReport.text = "";
                shopMenu.levelClear = false;
                shopMenu.shotgunBought = false;
                shopMenu.ArBought = false;
                shopMenu.cannonBought = false;
                shopMenu.temp_currentLevel = 1;

                Wall.current_wall_HP = 3;
                Wall.HP = 3;

                Spawner.level = 1;
                Spawner.fastHPBuff = 0;
                Spawner.fastSpeedBuff = 0;
                Spawner.slowSpeedBuff = 0;
                Spawner.slowHPBuff = 0;
                Spawner.flyingHPBuff = 0;
                Spawner.flyingSpeedBuff = 0;
                Spawner.BossHPBuff = 0;

                Spawner.leftToSpawn = 0;
                Spawner.currentlyAlive = 3;

                SceneManager.LoadScene(0);

                GameOver = false;

            }
            else Application.Quit();
        }
        if (Input.GetKeyDown("p"))
            Freeze();
    }
}



