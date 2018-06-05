using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

//Level manager is being used to control the UI inputs to change the game scene
	//has to be public to be used in other unity IDE
	public void LoadLevel(string name)
	{
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest()
	{
		Debug.Log("I want to quit");
		Application.Quit();	//this method is bad practice and should not be used - it will be rejected if you try to publsish application. 
	}

	public void MainMenu (string name)
	{
		Debug.Log("Main Menu Request");
		Application.LoadLevel(name);

	}
	/* note: if your plan is to pass the user through to a new scene in your game you need to define a string
			variable parameter in the method and input what scene is passed through next on the 'onClick' event
			in unity. other wise it will not show up in the drowp down function menu of said click event.
	*/
}
