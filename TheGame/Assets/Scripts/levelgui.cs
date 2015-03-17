using UnityEngine;
using System.Collections;

public class levelgui : MonoBehaviour {

	// Initialize level
	void Start () 
	{
		//print ("Loaded: " + gamestate.Instance.getLevel());
	}
	
	
	
	// ---------------------------------------------------------------------------------------------------
	// OnGUI()
	// --------------------------------------------------------------------------------------------------- 
	// Provides a GUI on level scenes
	// ---------------------------------------------------------------------------------------------------
	void OnGUI()
	{		
		// Create buttons to move between level 1 and level 2
		if (GUI.Button (new Rect (30, 30, 150, 30), "Spila leik"))
		{
			gamestate.Instance.setLevel();
			Application.LoadLevel("level1");
		}
		
		if (GUI.Button (new Rect (300, 30, 150, 30), "Innskráning"))
		{
			print ("Moving to level 2");
			gamestate.Instance.setLevel();
			Application.LoadLevel("LoginSena");
		}

	}
}