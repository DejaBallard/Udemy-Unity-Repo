using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {
	private StarDisplay starDisplay;
	public int starCost = 10;
	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStars(int amount){
		starDisplay.Addstars(amount);
	}


}
