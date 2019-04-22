using UnityEngine;
using System.Collections;

public class LoseTrigger : MonoBehaviour {
	private LevelManagerScript levelmanager;
	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D () {
		levelmanager.LoadLevel ("03b Lose");
	}
}
