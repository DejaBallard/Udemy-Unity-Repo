using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints;
    public bool respawnbool = false;
    public GameObject LandingAreaPrefab;

    private Transform[] spawnPoints;
    private bool lastToggle = false;


	// Use this for initialization
	/// <summary>
    /// 
    /// </summary>
    void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lastToggle != respawnbool)
        {
            Respawn();
            respawnbool = false;  
        }
        else { lastToggle = respawnbool; }
	}

    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }

    void OnClearArea()
    {
        Invoke("DropFlare", 3);
    }

    void DropFlare() {
        Instantiate(LandingAreaPrefab, transform.position, transform.rotation);
    }
}
