using UnityEngine;

public class CameraFollow : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//print (player.ToString ());

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position;
		
	}
}
