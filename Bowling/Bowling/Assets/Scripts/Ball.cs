using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool inPlay = false;
	
	private Rigidbody rigidBody;
	private AudioSource ballSound;
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		rigidBody = gameObject.GetComponent<Rigidbody>();
		ballSound =GetComponent<AudioSource>();
		rigidBody.useGravity = false;
	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		ballSound.Play ();
	}
	
	public void Reset(){
		inPlay = false;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		transform.position = startPosition;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
