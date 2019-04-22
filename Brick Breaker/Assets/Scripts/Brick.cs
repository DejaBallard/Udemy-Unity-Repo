using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public GameObject smoke;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public AudioClip Break;
	
	private int timesHit;
	private LevelManagerScript levelmanager;
	private bool isbreakable;
	
	// Use this for initialization
	void Start () {

		
		isbreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if (isbreakable){
			breakableCount++;
			print (breakableCount);
		}
		levelmanager = GameObject.FindObjectOfType<LevelManagerScript>();
		timesHit = 0;
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (isbreakable){
		HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			AudioSource.PlayClipAtPoint (Break, transform.position, 0.5f);
			breakableCount--;
			levelmanager.BrickDestoryed();
			GameObject smokepuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
			smokepuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
		}
		else{
			LoadSprites();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] !=null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
			Debug.LogError ("Brick Sprite Missing");
	}
	
}
