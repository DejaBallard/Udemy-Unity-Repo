using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text StarText;
	public int TotalAmount = 100;
	
	public enum Status {SUCCESS, FAILURE}
	// Use this for initialization
	void Start () {
		StarText = GetComponent<Text>();
		UpdateDisplay();
	}
	void UpdateDisplay(){
		StarText.text = TotalAmount.ToString();
		
	}
	
	public void Addstars(int amount){
		TotalAmount += amount;
		UpdateDisplay();
	}
	public Status Usestars(int amount){
		if (TotalAmount >= amount){
		TotalAmount -= amount;
		UpdateDisplay();
			return	Status.SUCCESS;
		}
			return Status.FAILURE;
	}
}

