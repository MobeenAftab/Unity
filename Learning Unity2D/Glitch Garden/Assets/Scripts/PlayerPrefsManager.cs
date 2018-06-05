//Author : Mobeen Aftab
//Date : 06/11/2015

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	/* the main similarity betwen this class of data storace is the data strcuture type of a hash map
	 * uding a 'Key' and a 'Value' to store data for the players preference. like options or cleared levels etc.
	 * but with this we are going to use a wrapper and modderate what goes into this bukket.
	 * note: that this file isnt encrypted an hackers could gain access and cheat your code. look at unity
	 * own video on how to encrypt such a file and further its use. search : PlayerPrefs :
	 * https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/persistence-data-saving-loading
	*/

	/* Wrapper class objective : 
	*  centralises all player prefs read/writes
	*  static so avalible from anywhere
	*  allows for checking / error hanling
	*/

	
	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULT_KEY = "difficulty";
	const string LEVEL_KEY = "level_locked_";	//not used in this game but can be for others

	/*
	* Note that most these methods below that set and get playerprefs are very similar to how you would normally use getters and setters
	*/

	//set the master volume
	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {	// volume range error checking
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);	//using PlayerPrefs to set KEY and VALUE (like hash map)
		} else {
			Debug.Log ("Master volume out of range");
		}
	}

	//get method for playerprefs file
	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);	//calls KEY and returns VALUE like hash map
	}

	public static void UnlockLevel (int level) {
		//error check scene count in build settings and minus 1 as unity starts count from 0
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); //use 1 for true
		} else {
			Debug.Log ("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked(int level) {

		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool IsLevelUnlocked = (level == 1);

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return IsLevelUnlocked;
		} else {
			Debug.Log ("trying to query level not in build order");
			return false;
		}
	}

	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULT_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULT_KEY);
	}

}