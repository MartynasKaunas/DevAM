using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {

    public Text endReport;
    bool ended;

    public void EndMePlz()
    {
        //išveda tik pirmą eilute su geim over, statistikoms gal nelieka vietos
        endReport.text = "ゲーム　オーワ" + System.Environment.NewLine + " You shot " + Enemy.count_deaths_this_enemy + " " + Enemy.name;

    }

    // Use this for initialization
    void Start()
    {
        endReport.text = "";
    }
}
