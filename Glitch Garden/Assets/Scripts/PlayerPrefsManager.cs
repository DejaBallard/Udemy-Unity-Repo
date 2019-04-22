using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY ="master_volune";
	const string DIFFICULTY_KEY ="difficulty";
	const string LEVEL_KEY="level_unlocked_";
	// Use this for initialization

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <=1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError ("Master Volume Fail");
		}
	}
	public static float GetMasterVolume (){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	
	public static void UnlockLevel (int level) {
		if (level <= Application.levelCount - 1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),1);
		}
		else{
			Debug.LogError("Level Unlock Error");
		}
	}
	
	public static bool IsLevelUnlocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue ==1);
		
		if (level <= Application.levelCount - 1){
			return isLevelUnlocked;
		}
		else{
			return false;
		}		
	}
	
	
	public static void SetDifficulty (float difficulty){
		if (difficulty >= 1f && difficulty <=3f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		}
		else{
			Debug.LogError ("Difficulty Error");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
	
}
