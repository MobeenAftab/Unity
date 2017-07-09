using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager LM;

	// Use this for initialization
	void Start () {
		
		LM = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D () {

		LM.LoadLevel ("03b Lose");
	}
}
