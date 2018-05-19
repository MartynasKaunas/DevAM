using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {
    void Update()
    {
        if (Player.current_player_HP > Player.player_HP * 2 / 3)
        {
            Destroy(gameObject);
            Player.smoke1 = false;
            Player.smoke2 = false;
        }
        if(Ending.GameOver == true)
        {
            Destroy(gameObject);
        }
    }
}
