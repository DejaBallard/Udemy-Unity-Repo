using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	public Slider VolumeSlider;
	public Slider DifficultySlider;
	public LevelManagerScript levelManager;
	
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		
		DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
		VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(VolumeSlider.value);
	}
	
	public void SetDefults(){
		VolumeSlider.value = 0.8f;
		DifficultySlider.value = 2f;
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (VolumeSlider.value);
		PlayerPrefsManager.SetDifficulty (DifficultySlider.value);
		levelManager.LoadLevel ("01a Start");
	}
}
