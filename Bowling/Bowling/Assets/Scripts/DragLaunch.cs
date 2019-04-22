using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}
	public void DragStart(){
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}
	
	public void DragEnd(){
		dragEnd = Input.mousePosition;
		endTime = Time.time;
		
		float dragDuration = endTime - startTime;
		float lauchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
		
		Vector3 launchVelocity = new Vector3 (lauchSpeedX, 0, launchSpeedZ);
		ball.Launch(launchVelocity);
	}
	
	public void MoveStart(float amount)
	{
		if(ball.inPlay == false){
			ball.transform.Translate (new Vector3 (amount,0,0));
	}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
