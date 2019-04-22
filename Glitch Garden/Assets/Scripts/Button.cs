using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	public bool selected;
	private Button[] buttonArray;
	private StarDisplay starDisplay;
	
	private Text costText;
	
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {Debug.LogWarning (name + " has no cost text");}
		
		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
		}
		
	// Update is called once per frame
	void Update () {

}
	void OnMouseDown(){

		foreach (Button thisbutton in buttonArray) {
			thisbutton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	
	}

}
