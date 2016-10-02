//Author : Mobeen Aftab
//Date : 05/11/2015

using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	//this class manages the music through-out the entire game by checking which build index scene is 
	//curently active and plays the according music file defined in the MusicManager inspector tabe > levelMusicChangeArray
	
	//public array that stores music files and playes acording to what scene game is in through
	//unitys build index.
	public AudioClip[] levelMusicChangeArray;

	//finding the audio files programitically
	private AudioSource audioSource;

	void Awake() {	//plays music throuout entire game
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont destroy on load " + name);
	}
	// Use this for initialization
	void Start () {
		 audioSource = GetComponent<AudioSource> ();
	}

	// keyword method is loaded as soon as scene was loaded
	void OnLevelWasLoaded(int level) {//if inspector gives you a size error on array scope, add 1 to array size to fix issue
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		Debug.Log ("Playing clip " + thisLevelMusic);

		if(thisLevelMusic) {	//if theres some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	//method to get volume change of audio source
	public void ChangeVolume(float volume) {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = volume;
	}
}
