using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public Transform prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void placeTraps()
	{
		
		Instantiate (prefab, new Vector3(0,0,0), Quaternion.identity);
		Instantiate (prefab, new Vector3(0,-1,0), Quaternion.identity);
		Instantiate (prefab, new Vector3(0,-3,0), Quaternion.identity);
	}
}
