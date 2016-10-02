using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;
	/*
	 * This class is used to instantly update the music level of the game after the user
	 * backs out of the options menu without having to restart the game
	 * 
	 */
	// Use this for initialization
	void Start () {

		musicManager = GameObject.FindObjectOfType<MusicManager> ();	//find music manager
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume ();	//get volume from slider
			musicManager.ChangeVolume (volume);	// set volume
		} else {
			Debug.LogWarning ("No music manager found on start scene");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
