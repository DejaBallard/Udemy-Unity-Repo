using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] AttackerPrefabArray;
	private GameTimer gametimer;
	private GameObject parent;
	// Use this for initialization
	void Start(){
		gametimer = FindObjectOfType<GameTimer>();
	}
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in AttackerPrefabArray){
			if (isTimeToSpawn(thisAttacker)){
				spawn(thisAttacker);
			}
			
	}
	}
	void spawn (GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject AttackerGameObject){
		Attacker attacker = AttackerGameObject.GetComponent<Attacker>();
		float spawnDelay = attacker.SeenEverySeconds;
		float spawnPerSeconds = 1/ spawnDelay;
		
		if (Time.deltaTime > spawnDelay){
			Debug.Log ("Spawn rate Capped by frame rate");
			}
		
		float threshold = spawnPerSeconds * Time.deltaTime / 5;
		return(Random.value <threshold);

		
	
	}
	
}
