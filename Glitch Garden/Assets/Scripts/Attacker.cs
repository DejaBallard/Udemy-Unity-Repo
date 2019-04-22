using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]

public class Attacker : MonoBehaviour {

	[Range (0f,1.5f)] public float walkSpeed;
	public float SeenEverySeconds;
	private GameObject currentTarget;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
		if (!currentTarget){
			anim.SetBool("isAttacking", false);
		}
		
	}
	
	void OnTriggerEnter2d(){
		Debug.Log ("TriggerEnter");
	}
	
	public void SetSpeed(float speed){
		walkSpeed = speed;
	}
	//Called From Animator
	public void StrikeCurrentTarget(float damage){
		if (currentTarget) {
		Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		}
	}
	// Called from Personal Script. 
	public void Attack (GameObject obj){
		currentTarget = obj;
		}
	
}
