using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject Gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		
	//Creats a Parent
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		setMyLaneSpawner();
	}
	
	
	// Update is called once per frame
	void Update () {
	if (isAttackerAhead()){
		animator.SetBool("isAttacking",true);
		}
	else{
		animator.SetBool("isAttacking",false);
		}
		
	}
	void setMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach (Spawner spawner in spawnerArray){
			if (spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + "No spawner");
	}
	bool isAttackerAhead(){
		if (myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		foreach (Transform attacker in myLaneSpawner.transform){
			if (attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		return false;
			
	}

	void fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = Gun.transform.position;
	}
}
