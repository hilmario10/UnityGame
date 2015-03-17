using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectLokaverkefni.Models.Transfer;
using System.Text;

public class gamestate : MonoBehaviour {
	
	// Declare properties
	private static gamestate instance;

		// Declare properties
	//private static gamestate instance;
	private UserModel user = new UserModel();
	private int activeLevel;			// Active level neing played
	private string name;
	public static int userid;           // userid of user.
	private int pass;					// pass of user
	private int scenesCleared;			// scenesCleared


	// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// --------------------------------------------------------------------------------------------------- 
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("gamestate").AddComponent<gamestate>();
			}
 
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	// ---------------------------------------------------------------------------------------------------
	
	
	// ---------------------------------------------------------------------------------------------------
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startState()
	{
		// Set default properties:
	    //activeLevel = "Level 1";
		//name = "My Character";	
		// Load level 1
		DontDestroyOnLoad(gamestate.Instance);
		Application.LoadLevel("level1");
	}

	// ---------------------------------------------------------------------------------------------------
	// getLevel()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the currently active level
	// ---------------------------------------------------------------------------------------------------
	public int getLevel()
	{
		return activeLevel;
	}
		
		
	// ---------------------------------------------------------------------------------------------------
	// setLevel()
	// --------------------------------------------------------------------------------------------------- 
	// Sets the currently active level to a new value
	// ---------------------------------------------------------------------------------------------------
	public void setLevel()
	{
		//Set activeLevel to newLevel
		//activeLevel = Application.loadedLevel;
	}

	// ---------------------------------------------------------------------------------------------------
	// getname()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the name of user
	// ---------------------------------------------------------------------------------------------------
	public string getName()
	{
		return name;
	}

	public int getUserid()
	{
		return userid;
	}
	
	public void setUserid(int value)
	{
		Debug.Log("Value sett sem userid " + value);
		userid = value;
	}	
		
	// ---------------------------------------------------------------------------------------------------
	// setName()
	// --------------------------------------------------------------------------------------------------- 
	// Sets name of user.
	// ---------------------------------------------------------------------------------------------------
	public void setName(string setname)
	{
		//Set activeLevel to newLevel
		name = setname;
	}

	public void loadNextLevel()
    {
        Costner sendList = gameObject.AddComponent<Costner>();
		sendList.BuildJsonObject();
        //yield return new WaitForSeconds(5);
        DontDestroyOnLoad(gamestate.Instance);
        {
        	Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

}