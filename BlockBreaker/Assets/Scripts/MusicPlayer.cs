//mobeen aftab
//31/12/2015

using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	//a static variable called instance of type music player
	static MusicPlayer instance = null;

	//awake is the very first method called to in a script, look at unity
	//execution model :: docs.unity3d.com/manual/executionOrder.html
	void Awake () {				//get instance generates a unique ID for log
		Debug.Log("Music PlayerPrefs Awake " + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print("Dublicate music player self destructing");
		}	// this will destroy any new music instance if one already exists
		else {	//else create a new instance
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			//gameObject = instance of the music player and this class
			//creates that instance through-out the entire run of the application
			//but this only starts at the beggining of the start scene once.
			}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
