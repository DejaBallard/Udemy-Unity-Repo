﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float DistanceToRaise = 40;
	public float StandingThreshold = 3f;
	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);
		
		if (tiltInX < StandingThreshold && tiltInZ < StandingThreshold){
			return true;
		} else{return false;}
	}
	// Update is called once per frame
	void Update () {
	}
	public void Rasie(){
			if (IsStanding()){
			rigidBody.useGravity = false;
			rigidBody.velocity = (new Vector3(0,0,0));
				transform.Translate (new Vector3 (0, DistanceToRaise, 0), Space.World);
			}
	}
	public void Lower(){
				transform.Translate (new Vector3 (0, -DistanceToRaise, 0), Space.World);
		rigidBody.velocity = (new Vector3(0,0,0));
		rigidBody.useGravity = true;
			
		}
	}
