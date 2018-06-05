using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//move object by continuously with uniform speed
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	
	}

	/*unity method to destroy any object when object is not visable in any camera
	void OnBecameInvisible () {
		Destroy (gameObject);
	} 
	Useed a shredder instead to avoid camera glitches - a 2d collider box that 
	destroys any object it collides with.
	*/

	//projectile collision with enemy objects
	void OnTriggerEnter2D (Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health>();

		//collision check on objects
		if(attacker && health){
			health.DealDamage (damage); //dealDamage to enemy
			Destroy (gameObject);	//destroy projectile instance
		}
	} 
}
