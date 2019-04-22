using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyesv2 : MonoBehaviour
{

    private Camera eyes;
    private float defaultFOV;


	// Use this for initialization
	void Start () {
        eyes = GetComponent<Camera>();
        defaultFOV = eyes.fieldOfView;
        print(defaultFOV);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Zoom"))
        {
            eyes.fieldOfView = defaultFOV / 1.5f;
        }
        else
        {
            eyes.fieldOfView = defaultFOV;
        }
	}
}
