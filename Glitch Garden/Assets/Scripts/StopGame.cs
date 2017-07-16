using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour {

	private LevelManager LM;

	void Start () {
		LM = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnMouseDown () {
		LM.LoadLevel ("01a Start");
	}
}
