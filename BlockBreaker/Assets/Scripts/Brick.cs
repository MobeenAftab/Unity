using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;	//an array to hold sprite images
	public static int breakableCount = 0;	//use static when you only want one instance
	public AudioClip crack;
	public GameObject smoke;

	//by using tags defined in the editor i can define what action is taken with objects of the same tag- its like grouping
	private bool isBreakable;
	private int timesHit;
	private LevelManager levelmanager;

	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print(breakableCount);
		}
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//changes enter to exit because brick would destroy object before applying physics engine
	void OnCollisionExit2D (Collision2D col) { 	
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if(isBreakable){
			HandleHits ();
		}
	} 

	void HandleHits() {
		
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			breakableCount--;
			levelmanager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void PuffSmoke() {
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject; //smoke particle system effect at position of brick
		Color brickColor = gameObject.GetComponent<SpriteRenderer>().color;
		smokePuff.GetComponent<ParticleSystem> ().startColor = brickColor;
	}

	//if object has been hit we want to call this method and load the sprite index of the array 
	//element position stored at timesHit - 1. note that arrays start incrementing at 0
	void LoadSprites() {
		int spriteIndex = timesHit - 1;

		if (hitSprites [spriteIndex] != null) {	//error handling of sprite if object has no assigned next sprite in spriteindex
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
			//calling the sprite renderer function in the unity inspector to change the sprite 
			//in our bricks sprite sheet programitically
		} else {
			Debug.LogError ("Sprite missing from : " + (spriteIndex + 1) +  "hitSprites Sprite on" + this.gameObject.name);
		}
	}
}