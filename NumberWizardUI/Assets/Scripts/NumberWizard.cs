	//Mobeen Aftab
	//29/12/2015

	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;

	public class NumberWizard : MonoBehaviour {

	//global scope variables that are not initilised but defined so 
	//both start and update functions can call variables
	int max;
	int min;
	int guess;

	public int maxGuessesAllowed = 10;	//this can be changed in script inspector
	public Text text;

	// Use this for initialization
	void Start () 
	{
	 	StartGame();
	}

	//both start game and next guess are class methods that are being called into 
	//the starts and update function. your code should look like this for best 
	//practice - using methods and calling parameter functions

	void StartGame() 
	{
		max = 1000;
		min = 1;
		NextGuess();
	}



	//Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.UpArrow))
	    {
	        //print("up arrow presed");
			GuessHigher();
	    }
	    else if (Input.GetKeyDown(KeyCode.DownArrow))
	    {
	        //print("down arrow presed");
			GuessLower();
	    }
	} 

	public void GuessHigher ()
	{
		min = guess;
		NextGuess ();
	}

	public void GuessLower ()
	{
		max = guess;
		NextGuess ();
	}

	void NextGuess ()
	{
		guess = Random.Range(min,max+1);
		maxGuessesAllowed = maxGuessesAllowed - 1;
		text.text = guess.ToString();
		if (maxGuessesAllowed <= 0) 
		{	//if 10incorect guesses have been made the player wins
			Application.LoadLevel("Win");
		}
	}

	}
