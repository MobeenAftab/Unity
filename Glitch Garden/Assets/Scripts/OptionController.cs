//Author : Mobeen Aftab
//Date : 06/11/2015

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

	/* TODO:: it took an absolute bitch of a time trying to figure out the null exception error this programme gives.
	 * note that in unity 5 things are done a little differently and every object must be instanciated
	 * otherwords, it must have been assigned to an gameobject of sorts even to its own class self otherwise
	 * unity 5 will throw you mega error and shit. look at exactly how i have done volume slider and level manager
	 * i have taken the global variables for each and found a GameObject of the type i am looking for. that one line will save you 
	 * a ton of debuging time and errors. trust me. write it down and explain it better so we dont ever get stuck again.
	 */

	/*Upadte :: i found out why i was having trouble, as i had declared public objects in this script i had not assigned 
	* each of the variables an object in the unity IDE inspector tab for the optioncontroller script, thats why you havd problems
	* what youve managed to do with the find objects of typeis programatically find these objects instead of using Unity UI to do the work.
	* both methods work but you cant have both methods on at the same time. either find it using the script or in unity UI
	*/

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		
		//this line will find an object of type MusicManager - the class we created and instanciate it to 
		//a new variable we choose, in this case its our private musicManager
		musicManager = GameObject.FindObjectOfType<MusicManager> ();	
		//volumeSlider = GameObject.FindObjectOfType<Slider> ();	//creating an instance of volumeSlider
		difficultySlider = GameObject.FindObjectOfType<Slider> ();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
	// Update is called once per frame
	void Update () {
		//dynamically update music volume while game runs
		if (musicManager != null) {	//this gets rid of the null instance error for updating music
			musicManager.ChangeVolume (volumeSlider.value);
		}
	}

	//sets option back to pre defined values by just adjusting the value on the sliders
	public void SetDefault () {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}

	//a method for the back button the writes new option changes to player pref
	public void SaveAndExit() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();	//creating an instance of levelManager of type class LevelManager
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);	//updating player prefs files
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}
}
