using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float setTime;
	private GameObject winLabel;
	private LevelManagerScript levelmanager;
	private float timer;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	// Use this for initialization
	void Start () {
		winLabel = GameObject.Find("WinLabel");
		levelmanager = GameObject.FindObjectOfType<LevelManagerScript>();
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		winLabel.SetActive(false);
		slider.maxValue = setTime;
		slider.value = 0f;
		timer = 1 * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value += timer;
		if (slider.value >= slider.maxValue && !isEndOfLevel){
			WonLevel();
		}	

	}
	void LoadNextLevel(){
		levelmanager.LoadNextLevel();
	}
	

	public void WonLevel(){
		audioSource.Play();
		winLabel.SetActive(true);
		Invoke("LoadNextLevel",audioSource.clip.length);
		isEndOfLevel = true;
	}
	
	
}
