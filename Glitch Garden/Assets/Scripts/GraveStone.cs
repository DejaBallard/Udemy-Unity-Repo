﻿using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		if (attacker){
			anim.SetTrigger("underAttackTrigger");
		}
	}
}
