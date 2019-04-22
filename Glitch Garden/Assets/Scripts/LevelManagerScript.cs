using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour {
	

	
	void Start(){
		if (Application.loadedLevel ==0){
		Invoke ("LoadNextLevel",3);
		}
	}
	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: "+name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest () {
		Debug.Log("Quit game requested");
		Application.Quit();
	}
	
public void LoadNextLevel(){
Application.LoadLevel(Application.loadedLevel + 1);
}
}

