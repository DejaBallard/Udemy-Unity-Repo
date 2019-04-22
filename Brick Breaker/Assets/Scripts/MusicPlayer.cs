using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	// Use this for initialization
	void Start () {
	//instance not = null then destory the new player
		if (instance != null)
		{
		Destroy (gameObject);
		print ("Duplicate Music Player Destroyed");
		}
		else
		{
		instance = this; 
		GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
