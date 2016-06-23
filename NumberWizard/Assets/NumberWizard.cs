	//Mobeen Aftab
	//29/12/2015

	using UnityEngine;
	using System.Collections;

	public class NumberWizard : MonoBehaviour {

	//global scope variables that are not initilised but defined so 
	//both start and update functions can call variables
	int max;
    int min;
    int guess;

	// Use this for initialization
	void Start () {

	 	StartGame();

	}

	//both start game and next guess are class methods that are being called into 
	//the starts and update function. your code should look like this for best 
	//practice - using methods and calling parameter functions

	void StartGame() {
		max = 1000;
    	min = 1;
    	guess = 500;

	    print("Welcome to number wizard!");
	    print("pick a number in your head and"
	        + "dont tell me");
	     
	    print("The higest number you can pick is " + max + "\n" + "and the lowest is " + min );
	    print("is the number higher or lower than " + guess);
	    print("up = higher, down = lower, return = equal");

		max = max + 1;


	}



	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.UpArrow))
	    {
	        //print("up arrow presed");
	        min = guess;
			NextGuess();
	    }
	    else if (Input.GetKeyDown(KeyCode.DownArrow))
	    {
	        //print("down arrow presed");
			max = guess;
	        NextGuess();
	    }
	    else if (Input.GetKeyDown(KeyCode.Return))
	    {
	        print("You Won!");
	        StartGame();
	    }

	}

	void NextGuess () {

		guess = (max + min) / 2;
	    print("Higher or Lower than " + guess);
	}

}
