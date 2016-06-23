//mobeen aftab
//30/12/2015

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		//Application.LoadLevel (name); is old in unity 5 use code below and import scene managment package into project
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		//this is using unity 5 new method of loading the next level programatically
		//it will find the current build index of this level and increment it by 1
		//effectivley loading the next level
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BrickDestroyed() {
		//calling breakable count method from brick class as it is a public class
		if (Brick.breakableCount <= 0 ) {	//last brick is destroyed
			LoadNextLevel();
		}
	}
}
