using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont destory on load" +name);
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		audioSource.Play();

	}
	
	void Start(){
		//audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded (int level){
		AudioClip thislevelmusic = levelMusicChangeArray[level];
		Debug.Log ("Play clip: " + thislevelmusic);
		
		if (thislevelmusic){
			audioSource.clip = thislevelmusic;
			audioSource.loop = true;
			if (!audioSource.isPlaying){
			audioSource.Play();
			}
		}
	}
	
	public void ChangeVolume (float newVolume){
		audioSource.volume = newVolume;
	
	}
}
