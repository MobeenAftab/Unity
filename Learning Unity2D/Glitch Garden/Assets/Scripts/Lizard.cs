using UnityEngine;
using System.Collections;

//check if attacker component is attached to fox object
[RequireComponent (typeof (Attacker))]

public class Lizard : MonoBehaviour {
	//Gaining access to the animator component class
	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	//find animator on start
		attacker = GetComponent<Attacker>();
	}

	// Update is called once per frame
	void Update () {

	}
	//collision detection with Fox
	void OnTriggerEnter2D (Collider2D collider) {	

		GameObject obj = collider.gameObject;
		//GetComponent<collider>();	//obj = collision object in game
		//Abort if not colliding with defender
		if( !obj.GetComponent<Defender>()){
			return;
		}
		//Lizard attacks any defender
		anim.SetBool("isAttacking", true);
		attacker.Attack (obj);

		Debug.Log ("Lizard " + GetComponent<Collider>());

	}
}
