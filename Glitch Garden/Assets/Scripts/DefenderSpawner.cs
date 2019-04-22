using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;
	public GameObject parent;
	
	private StarDisplay starDisplay;
	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		parent = GameObject.Find("Defenders");
		if (!parent){
			parent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalcuateWorldPoint();
		Vector2 Pos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defenders>().starCost;
		if (starDisplay.Usestars(defenderCost) == StarDisplay.Status.SUCCESS){
		SpawnDefender(Pos, defender);
		}
		else{
			print ("no money");
		}
	}
	
	void SpawnDefender(Vector2 Pos, GameObject defender){
		GameObject newDef = Instantiate (defender,Pos,Quaternion.identity) as GameObject;
		newDef.transform.parent = parent.transform;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos){
		
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX,newY);
	}

	Vector2 CalcuateWorldPoint(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3 (mouseX,mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		return worldPos;
	
	}

}
