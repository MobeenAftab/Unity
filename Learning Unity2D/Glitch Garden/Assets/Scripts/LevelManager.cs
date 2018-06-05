//Author : Mobeen Aftab
//Date : 05/11/2015

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	//this float is a timer which sets how long the splash screen should show
	public float autoLoadNextLevelAfter;

	void Start () {
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disabled, use a postive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
