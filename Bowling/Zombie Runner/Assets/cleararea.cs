using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleararea : MonoBehaviour {

    public float timeSinceLastTrigger = 0;

    private bool foundarea = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if (timeSinceLastTrigger > 2f && Time.realtimeSinceStartup > 10f && !foundarea)
        {
            foundarea = true;
            SendMessageUpwards("OnClearArea");
        }
	}

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Player")
        {
            timeSinceLastTrigger = 0;
        }
    }
}
