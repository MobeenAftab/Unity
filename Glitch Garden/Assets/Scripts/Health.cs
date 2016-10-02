using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float heatlth = 100f;

	//Deal damage method for attackers to update current object health
	public void DealDamage(float damage) {
		heatlth -= damage;
		if(heatlth < 0){	//death trigger
			//optionally trigger death animation
			DestroyObject();
		}
	}

	//destroy instance of gameObject not health
	public void DestroyObject() {
		Destroy (gameObject);
	}
}
