using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public Text standingDisplay;
	public GameObject pinSet;
	public bool ballOutOfPlay = false;	
	
	private int LastStandingCount = -1;
	private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;
	private int lastSettledCount = 10;
	private float lastChangeTime;
	private Ball ball;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text =CountStanding().ToString();
		if (ballOutOfPlay){
			UpdateStandingPins();
			standingDisplay.color = Color.red;
		}
	}

	public int CountStanding()
	{
	int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				standing ++;
			}
		}
		return standing;
	}
	
	void OnTriggerExit(Collider collider){
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.GetComponent<Pin>()){
			Destroy(thingLeft);
		}
	}	
	
	void UpdateStandingPins(){
		int currentStanding = CountStanding();
		if (currentStanding != LastStandingCount){
			lastChangeTime = Time.time;
			LastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime){
			PinsHaveSettled();
		}
	}
	
	void PinsHaveSettled(){
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;
		
		ActionMaster.Action action = actionMaster.Bowl(pinFall);
		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		}else if(action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		}else if(action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		}else if(action == ActionMaster.Action.EndGame){
			throw new UnityException ("no end game handle");
		}
		ball.Reset();
		LastStandingCount = -1;
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}
	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Rasie();
		}
	}

	public void LowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
	
	}
	public void RenewPins(){
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3(0,+40,0);
	}
}
