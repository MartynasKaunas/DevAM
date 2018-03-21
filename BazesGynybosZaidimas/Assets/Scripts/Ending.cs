using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    public Text endReport;
    bool ended;
    public static bool IsDead = false;// del audio 
    public void EndMePlz()
    {
        endReport.text = "GAME OVER" /*ゲーム　オーワ"*/ + System.Environment.NewLine + " You shot " + Enemy.count_deaths_this_enemy + " " + Enemy.name;
        Debug.Log("gg");//test
        IsDead = true;
    }

    // Use this for initialization
    void Start()
    {
        endReport.text = "";
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
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.GetKey("p"))
            Freeze();
    }
}

