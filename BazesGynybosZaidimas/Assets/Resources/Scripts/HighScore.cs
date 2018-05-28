using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	public Text highScore;
	// Use this for initialization
	void Start () {
		highScore.text = PlayerPrefs.GetInt ("HighScore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setScore()
	{
        highScore.text = "New high score!";
        if ((Player.score > PlayerPrefs.GetInt ("HighScore", 0)) && Player.current_player_HP <= 0) {
			PlayerPrefs.SetInt ("HighScore", Player.score);
		}
	}
}
