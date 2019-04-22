﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneCollider : MonoBehaviour {
	
	private PinSetter pinSetter;
	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name == "Ball"){
			pinSetter.ballOutOfPlay = true;
		}
	}
}
