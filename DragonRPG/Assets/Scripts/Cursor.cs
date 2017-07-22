using UnityEngine;

public class Cursor : MonoBehaviour {

	CameraRaycaster CR;

	// Use this for initialization
	void Start () {

		CR = GetComponent<CameraRaycaster> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//print (CR.layerHit);
	}
}
