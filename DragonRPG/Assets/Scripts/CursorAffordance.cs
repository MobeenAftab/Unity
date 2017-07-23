using UnityEngine;

// An affordance is the possibillity of an action on an object or enviroment
public class CursorAffordance : MonoBehaviour {

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
