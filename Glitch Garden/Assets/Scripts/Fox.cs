using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]

public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log ("Fox hit: " + collider);
		
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defenders>()){
			return;
		}
		
		if (obj.GetComponent<GraveStone>()){
			anim.SetTrigger("JumpTrigger");
		}
		else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
