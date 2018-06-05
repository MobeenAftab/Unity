using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float totalTime = 100;

	private Slider slider;
	private AudioSource AS;
	private LevelManager LM;
	private GameObject levelComplete;
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {

		slider = GetComponent<Slider> ();
		AS = GameObject.FindObjectOfType<AudioSource> ();
		LM = GameObject.FindObjectOfType<LevelManager> ();

		LevelComplete ();
		levelComplete.SetActive (false);


	}

	void LevelComplete () {
		levelComplete = GameObject.Find ("LevelComplete");
		if (!levelComplete) {
			Debug.LogWarning ("Cannot find Level Complete Object > lable");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//proportion of progress through level
		slider.value = Time.timeSinceLevelLoad / totalTime;

		if (Time.timeSinceLevelLoad >= totalTime && !isGameOver) {
			WinCondition ();
		}
	}

	void LoadNextLevel () {

		LM.LoadNextLevel ();
	}

	void WinCondition () {
		DestroyAllTaggedObjects();
		AS.Play();
		levelComplete.SetActive (true);
		Invoke("LoadNextLevel", AS.clip.length);
		isGameOver = true;
	}

	void DestroyAllTaggedObjects () {
		GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("DestroyOnWin");

		foreach (GameObject tagObj in taggedObjects) {
			Destroy(tagObj);
		}
	}
}
