using UnityEngine;
using System.Collections;

//saftey chack all attackers have rigidbody2D
[RequireComponent (typeof (Rigidbody2D))]

public class Attacker : MonoBehaviour {

	//what [range()] does is create a slider option in the unity inspector that
	//allows us to change the walkSpeed float variable within the pre defined range
	//[Range (-1f, 1.5f)] public float currentSpeed; - made private

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		/*adds ridgidbody kinematic to each attacker object using script
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		** required component now checks for ridged body component as pre requisite of any 
		*attacker object
		*/

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Transform.Translate moves the transform (position) in the direction and distance of translation
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		//setting animation state of attacker to false after attacking phase is finished
		if(!currentTarget){
			anim.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D () {
		Debug.Log (name + " trigger enter");
	}

	//allwos the animator 'add event' funcction to set the speed of the object vai a
	//method updating the 'currentSpeed' float
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	//Called from the animator at the time of actual attack
	public void StrikeCurrentTarget(float damage) {
		if (currentTarget) {	//strike only if attack is true/enemy selected
			Health health = currentTarget.GetComponent<Health> ();
			Debug.Log (name + " caused damage: " + damage);
			if(health){//if health object true remove total damage of attack
				health.DealDamage (damage);//calling health method and remove this.damage on object health
			}
		}
	}
	//Method for attacking another object - takes in another object as argument
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
