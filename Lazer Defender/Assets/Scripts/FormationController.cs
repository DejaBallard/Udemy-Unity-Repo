using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {
	public GameObject Thruster;
	public GameObject enemyPrefab;
	public float speed = 5f;
	public float width = 10f;
	public float height = 5f;
	public float spawnDelay = 0.5f;
	private bool movingright = true;
	float xmin ;
	float xmax ;
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmax =rightmost.x;
		xmin =leftmost.x;
		
		SpawnUntillFull();
		
		
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingright){
		transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else{
		transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		
		float rightedgeofformation = transform.position.x + (0.5f*width);
		float leftedgeofformation = transform.position.x - (0.5f*width);
		if (leftedgeofformation < xmin){
			movingright = true;
		}
		else if (rightedgeofformation > xmax){
			movingright = false;
		}
		
		if (AllMembersDead()){
			Debug.Log("Empty Formation");
			SpawnUntillFull();
		}
	}

	Transform NextFreePosition(){
		foreach (Transform childPostionGameObject in transform){
			if (childPostionGameObject.childCount == 0){
				return childPostionGameObject;
			}
		}
		return null;
	}	
		bool AllMembersDead(){
		foreach (Transform childPostionGameObject in transform){
			if (childPostionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
}
		
		
	//void SpawnEnemies(){
	//	foreach(Transform child in transform){
	//		GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
	//		enemy.transform.parent = child;		
	//	}
//	}
	
	void SpawnUntillFull(){
		Transform freePosition = NextFreePosition();
		if (freePosition){
		GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = freePosition;	
		}
		if(NextFreePosition()){
		Invoke("SpawnUntillFull",spawnDelay);
		}
	}
	
}
