﻿
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	//Declaration of global variables
	//enum creates contant states for different sections of the game
	//private states creates variable for declaring current state in each room
	public Text text;
	private enum States {cell, mirror, sheets_0, sheets_1, lock_0, cell_mirror, lock_1, freedom, corridor_0, corridor_1,
						corridor_2, corridor_3, stairs_0, stairs_1, stairs_2, closet_door, in_closet, closet_hide, floor};	//constant states for game
	private States myStates;
	
	// Use this for initialization
	//starts the game in the cell state everytime
	void Start () 
	{
		myStates = States.cell;
	}
	
	// Update is called once per frame
	//Declaration of methods for different states
	void Update () 
	{
		print(myStates);
		if (myStates == States.cell)	//if myStates becomes states.cell
		{								//assign state to state_cell
			state_cell();				//state_cell is a method with its own paramaters/instructions
										//this will send user to state_cell until myStaes equals other 
		}
		else if (myStates == States.sheets_0)	//myStates = current state of user
		{										// after == operation becomes new state of user. after state. end variable = enum variable
			State_sheets_0();					//state_xxx refrences the void method of newly accessed state
		}
		else if (myStates == States.lock_0)
		{
			State_lock_0();
		}
		else if(myStates == States.mirror)
		{
			State_mirror();
		}
		else if (myStates == States.cell_mirror)
		{
			State_cell_mirror();
		}
		else if (myStates == States.sheets_1)
		{
			State_sheet_1();
		}
		else if (myStates == States.lock_1)
		{
			State_lock_1 ();
		}
		else if (myStates == States.corridor_0)
		{
			State_corridor_0();
		}
		else if (myStates == States.stairs_0)
		{
			State_stairs_0();
		}
		else if (myStates == States.stairs_1)
		{
			State_stairs_1();
		}
		else if (myStates == States.stairs_2)
		{
			State_stairs_2();
		}
		else if (myStates == States.closet_door)
		{
			State_closet_door();
		}
		else if (myStates == States.floor)
		{
			State_floor();
		}
		else if (myStates == States.in_closet)
		{
			State_in_closet();
		}
		else if (myStates == States.corridor_1)
		{
			State_corridor_1();
		}
		else if (myStates == States.corridor_2)
		{
			State_corridor_2();
		}
		else if (myStates == States.corridor_3)
		{
			State_corridor_3();
		}
		else if (myStates == States.closet_hide)
		{
			State_closet_hide();
		}
		else if (myStates == States.freedom)
		{
			State_freedom();
		}
	}
	
	//methods created for myStates and their own paramaters
	
	//starting state
	void state_cell()	//name method reference. notice the lack of pural and '_' indicating single state and unique method name
	{
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall and the door " +
					"is Locked from the outside.\n\n" +
					"Press 'S' to view sheets\n" + 	//offeres user optionts to change
					"Press 'M' to view mirror\n" + //current state 
					"Press 'L' to view lock\n";
		
		if (Input.GetKeyDown(KeyCode.S))	//changes state to sheets
		{
			myStates = States.sheets_0;		//refrencing above method for change of states
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			myStates = States.lock_0;	
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			myStates = States.mirror;
		}
	}
	
	void State_sheets_0()
	{
		text.text = "you cant believe you sleep in these things. Suerly its " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess\n\n" +
					"Press 'R' to return to roaming your cell\n";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myStates = States.cell;
		}
	}
	
	void State_lock_0()
	{
		text.text = "this is one of thoes button locks. you have no idea what the " +
					"combination is. you wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help\n\n" +
					"Press 'R' to return to roaming your cell\n";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myStates = States.cell;
		}
	}
	
	
	void State_mirror()
	{
		text.text = "he dirty old mirror on the wall seems loose.\n\n" +
					"Press 'T' to Take the mirror\n" +
					"Press 'R' to return to roaming your cell\n";
					
		if (Input.GetKeyDown(KeyCode.R))
		{
			myStates = States.cell;
		}
		else if (Input.GetKeyDown(KeyCode.T))
		{
			text.text = "You have taken the mirror";
			text.text = "You return to the cell with the mirror";
			myStates = States.cell_mirror;
		}
	}
	
		void State_cell_mirror()
		{
			text.text = "You are still in your cell, and you STILL want to escape! There are " +
						"some dirty sheets on the bed, a mark where the mirror was, " +
						"and that pesky door is still there, and firmly locked!\n\n" +
						"Press S to view Sheets\n" +
						"Press L to view Lock";
			
			if (Input.GetKeyDown(KeyCode.S))
			{
				myStates = States.sheets_1;
			}
			else if(Input.GetKeyDown(KeyCode.L))
			{
				myStates = States.lock_1;
			}
		}
		
	void State_sheet_1()
	{
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press 'R' to return to roaming your cell\n";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myStates = States.cell_mirror;
		}
	}
	
	void State_lock_1()
	{
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press 'O' to Open\n" +
					"Press 'R' to Return to your cell" ;
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myStates = States.cell_mirror;
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			myStates = States.corridor_0;
		}
	}
	
	void State_corridor_0()
	{
		text.text = "you are now in a corridor you see stairs, epmtly " +
					"empty floor space and a closet\n\n" +
					"Press 'S' to go up stairs\n" +
					"Press 'F' to inspect floor\n" +
					"Press 'C' to inspect closet";
		
		if (Input.GetKeyDown (KeyCode.S))
		{
			myStates = States.stairs_0;
		}
		else if (Input.GetKeyDown (KeyCode.F))
		{
			myStates = States.floor;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			myStates = States.closet_door;
		}
	}
	
	void State_stairs_0()
	{
		text.text = "The stairs lead to a dead end with the only way but the door is locked " +
					"and i cant find a way to open it for now.\n\n" +
					"Press 'O' to return";
		
		if (Input.GetKeyDown (KeyCode.O))
		{
			myStates = States.corridor_0;
		}
	}
	
	void State_stairs_1()
	{
		text.text = "The stairs lead to a dead end with the only way but the door is locked " +
					"and i cant find a way to open it for now.\n\n" +
					"Press 'O' to return";
		
		if (Input.GetKeyDown (KeyCode.O))
		{
			myStates = States.corridor_1;
		}
	}
	
	void State_closet_door()
	{
		text.text = "The closet seems to be locked. no way to open it right now.\n\n" +
					"Press 'O' to return";
		
		if (Input.GetKeyDown (KeyCode.O))
		{
			myStates = States.corridor_0;
		}
	}
	
	void State_floor()
	{
		text.text = "The floor seems to be nothing but empty space but " +
					"there is a small bobby pin lying here\n\n" +
					"Press 'P' to take the bobby pin\n"+
					"Press 'O' to return";
					
		if (Input.GetKeyDown (KeyCode.O))
		{
			myStates = States.corridor_0;
		}
		else if (Input.GetKeyDown (KeyCode.P))
		{
			myStates = States.corridor_1;
		}
	}
	
	void State_corridor_1()
	{
		text.text = "Now maybe i can use this bobby pin to help me get out of here\n\n" +
					"Press 'S' to go up stairs\n" +
					"Press 'C' to inspect closet";
		if (Input.GetKeyDown (KeyCode.S))
		{
			myStates = States.stairs_1;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			myStates = States.in_closet;
		}
	}
	
	void State_in_closet()
	{
		text.text = "You have used the bobby pin to open the locked closet. " +
					"You now see police uniform hanging by\n\n" +
					"Press 'D' to put on uniform\n" +
					"press 'O' to return";
		
		if (Input.GetKeyDown (KeyCode.D))
		{
			myStates = States.corridor_2;
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			myStates = States.corridor_1;
		}
	}
	
	void State_corridor_2()
	{
		text.text = "Suddenly you hear a noise. its two police officers walking down the stairs " +
					"you can try to hide and hope they dont see through your disguse or...\n\n" +
					"Press 'H' to Hide in closet\n" +
					"press 'D' to use disguse and act like a guard heading for the stairs";
					
		if (Input.GetKeyDown (KeyCode.H))
		{
			myStates = States.closet_hide;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			myStates = States.corridor_3;
		}
	}
	
	void State_closet_hide()
	{
		text.text = "You watch as the officers walk past and head a different direction " +
					"from you. For now you are safe and disguised\n\n" +
					"press 'D' to walk up the stairs and through the previously locked door";
					
		if (Input.GetKeyDown(KeyCode.D))
		{
			myStates = States.corridor_3;
		}
	}
	
	void State_corridor_3()
	{
		text.text = "You calmly walk past the guards area as to not bring any attention to yourself. " +
					"The previously locked door from the stairs is now open\n\n" +
					"Press 'C' to continue walking\n" ;
					
		if (Input.GetKeyDown (KeyCode.C))
		{
			myStates = States.stairs_2;
		}
	}
	
	void State_stairs_2()
	{
		text.text = "you can hear the wind howling outside and smell the " +
					"fresh air. freedom is almost upon you\n\n" +
					"Press 'R' to run to your freedom";
					
		if (Input.GetKeyDown (KeyCode.R))
		{
			myStates = States.freedom;
		}
	}

	void State_freedom()	//final mathod and state
	{
		text.text = "You are FREE!\n\n" +
					"Press 'P' to play again";	//perfectly loops the game back to the begining 
												//resetting all previous action of taking the mirror
	
		if (Input.GetKeyDown(KeyCode.P))
		{
			myStates = States.cell;
		}
	
	}
}

/*
//Mobeen Aftab
//29/12/2015

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	//global text variable text of type Text
	public Text text;
	public Text helpText;

	//enum is a distinct type of a set named constants called the enumerator list
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};	//the enumerator list
	//setting the enum list 'States' to a variable called 'myState' to minipulate states as a normall variable 
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;	//first state is cell
	}
	
	// Update is called once per frame
	void Update ()
	{

		print (myState);
		if (myState == States.cell) {
			state_cell ();	//stes myState to state cell if myStates == States.cell
		} else if (myState == States.sheets_0) {
			state_sheets_0 ();	//else if set to sheets state etc.. this pattern goes on for other states
		} else if (myState == States.lock_0) {
			state_lock_0 ();
		}
	
	}

	//Methods for various game/level states for update method

	void state_cell ()
	{		//you are using the global text variable to programatically change the text in the UI
		text.text = "You are currently in a prison cell and you want to escape. there are " +
		"some dirty sheets on the bed, a mirror on the wall and the door is " +
		"loked from the outside. \n\n" +
		"Press S to view sheets, M to view mirror and L to view lock";

		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		}
	}

	void state_sheets_0 ()
	{		//you are using the global text variable to programatically change the text in the UI
		text.text = "You cant believe you sleep in these things. surley it's " +
		"time somebody changed them. the pleasures of prison life " +
		"I guess. \n\n" +
		"Press R to Return to roaming your cell";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}

	}

	void state_lock_0 ()
	{		//you are using the global text variable to programatically change the text in the UI
		text.text = "This is one of those button locks. " +
		"time somebody changed them. the pleasures of prison life " +
		"I guess. \n\n" +
		"Press R to Return to roaming your cell";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}

	}
}

All of the code below is re-rwitten when i started the unity tut walkthrough again. 
i have just copied the code from my older version as the code is mostly reppetition.
 old files are on PC.
*/

