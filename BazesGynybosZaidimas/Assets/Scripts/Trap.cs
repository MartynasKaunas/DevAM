using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public Transform prefab;
	public static bool trapsPlaced = false;
	public static int usedTraps = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (usedTraps == 3) {
			trapsPlaced = false;
			usedTraps = 0;
		}
	}
	public void placeTraps()
	{
		if (trapsPlaced == false && Player.score >= 15) {
			Instantiate (prefab, new Vector3 (0, 0, 0), Quaternion.identity);
			Instantiate (prefab, new Vector3 (0, -1, 0), Quaternion.identity);
			Instantiate (prefab, new Vector3 (0, -3, 0), Quaternion.identity);
			trapsPlaced = true;
			Player.score -= 15;
		}
	}
}
