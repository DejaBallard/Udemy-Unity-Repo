using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public GameObject Projectile;
	public AudioClip Firing;
	public AudioClip Death;
	
	public float Health =150;
	public float ProjectileSpeed;
	public float ShotsPerSecounds = 0.5f;
	public int ScoreValue = 150;
	
	private ScoreKeeper scorekeeper;
	
	void Start(){
		scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			Health -= missile.GetDamage();
			missile.Hit();
			if (Health <=0){
				AudioSource.PlayClipAtPoint(Death,transform.position,0.1f);
				Destroy(gameObject);
				scorekeeper.Score(ScoreValue);
			}
			Debug.Log ("Hit by missile");
		}
	}
	
	void Update(){
		float probability = Time.deltaTime * ShotsPerSecounds;
		if (Random.value < probability){
		Fire();
		}
	}
	void Fire(){
		Vector3 startposition = transform.position + new Vector3 (0,-1,0);
		AudioSource.PlayClipAtPoint(Firing,transform.position,0.1f);
		GameObject Missile = Instantiate(Projectile,startposition, Quaternion.identity) as GameObject;
		Missile.rigidbody2D.velocity = new Vector2(0,-ProjectileSpeed);
	}
}
