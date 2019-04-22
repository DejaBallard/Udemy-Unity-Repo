using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {


    private bool called = false;


    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnDispatch()
    {
        if (!called)
        {
            called = true;
            rigidBody.velocity = new Vector3(0, 0, 50f);
        }
    }
}
