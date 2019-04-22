using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManagerScript levelmanager;
	
	void OnTriggerEnter2D (Collider2D trigger){
		levelmanager = GameObject.FindObjectOfType<LevelManagerScript>();
		levelmanager.LoadLevel("Lose");
		Brick.breakableCount = 0;
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		print ("Collision");
	}
}
