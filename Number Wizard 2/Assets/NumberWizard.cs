using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	
	int max;
	int min;
	int guess;
	int maxguesses = 20;
	
	public Text Number;
	
	void Start () {
	StartGame();
	}
	
	void StartGame () {
		max = 1001;
		min = 1;
		NextGuess();
	}
	
	void NextGuess () {
		guess = Random.Range(min,max+1);
		Number.text = guess.ToString();
		maxguesses = maxguesses - 1;
		if(maxguesses <= 0) 
		{Application.LoadLevel("Win");}
	}

	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.UpArrow)) {
			GuessHigher();
	}
	else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			GuessLower();
	}
	}
	
	public void GuessHigher(){
	
		min = guess;
		NextGuess();
	}
	
	public void GuessLower(){
	
		max = guess;
		NextGuess();
	}
	
	
}
