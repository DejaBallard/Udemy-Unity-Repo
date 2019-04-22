using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text ScoreText;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();
	}
	
	
	public void Score(int points){
		Debug.Log ("point");
		score += points;
		ScoreText.text = score.ToString();
	}
	
	
	public static void Reset(){
		score = 0;
	}

}
