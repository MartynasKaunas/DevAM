using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	//Too access variables from different scripts variable should be changed to static

	public int enemySpeed = 1; // How fast enemy is moving




	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		Movement (); 
		                                                                    
	}

	public void Movement(){
		
		transform.Translate (Vector2.right * Time.deltaTime * enemySpeed);

	}
	// To Do: EnemyHealth is reduced dependig on what tipe of gun he got shot at.
	public void Health()
	{


	}

}
