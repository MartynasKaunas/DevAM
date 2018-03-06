using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {

    public Text endReport;
    bool ended;

    public void EndMePlz()
    {
        endReport.text = "GAME OVER" /*ゲーム　オーワ"*/ + System.Environment.NewLine + " You shot " + Enemy.count_deaths_this_enemy + " " + Enemy.name;
    }

    // Use this for initialization
    void Start()
    {
        endReport.text = "";
    }
}
