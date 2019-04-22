using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycycle : MonoBehaviour {

    [Tooltip("Number of minutes per second that pass")]
    public float timeScale = 300;

    
	// Use this for initialization
	void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        float angleThisFram = Time.deltaTime / 360 * timeScale;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFram);
	}
}
