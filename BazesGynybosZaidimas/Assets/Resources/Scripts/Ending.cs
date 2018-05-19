using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    public Text endReport;
    public static bool GameOver = false;

    public AudioClip GameOverMusic;
    public AudioSource SpawnerAudioSource;
    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        endReport.text = "";
    }

    public void EndMePlz()
    {
        SpawnerAudioSource.Stop();
        audioSource.PlayOneShot(GameOverMusic);
        endReport.text = "GAME OVER" /*ゲーム　オーワ"*/ + System.Environment.NewLine + " You shot " + Enemy.count_deaths_this_enemy + " Enemies";
        GameOver = true;
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
                Taikymasis.weaponType = 1;
                Taikymasis.speed = 45;

                endReport.text = "";
                shopMenu.levelClear = false;
                shopMenu.shotgunBought = false;
                shopMenu.cannonBought = false;

                Spawner.level = 1;
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

