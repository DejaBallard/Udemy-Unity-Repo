using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float Health = 250;
	public float speed;
	public float padding;
	public float ProjectileSpeed;
	public float FireRate = 0.2f;
	
	public GameObject Projectile;
	
	float xmin ;
	float xmax ;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin =leftmost.x +padding;
		xmax =rightmost.x -padding;
	}
	
	void Fire(){
		Vector3 startposition = transform.position + new Vector3 (0,+1,0);
		audio.Play();
		GameObject beam = Instantiate(Projectile,startposition, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3 (0, ProjectileSpeed,0);
	}
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire",0.000001f, FireRate);
		}
	
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		    }
		    
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			Health -= missile.GetDamage();
			missile.Hit();
			if (Health <=0){
				Destroy(gameObject);
				Application.LoadLevel("Lose");
			Debug.Log ("Hit by missile");
			}
		
		}
	}
}
