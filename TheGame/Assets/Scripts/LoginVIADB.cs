using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class LoginVIADB : NetworkScript {

	private float REC_WIDTH = Screen.width / 2;
	private float REC_HEIGHT = Screen.height / 2;
	private string username = "";
	private string pass = "";
	//public static LoginScriptViaDataBase log;
	//public int aldur;

    void OnGUI () {
	    // Make a group on the center of the screen
	    GUI.BeginGroup (new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2));
	    // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

	    // We'll make a box so you can see where the group is on-screen.
	    GUI.Box (new Rect (0,0,REC_WIDTH,REC_HEIGHT), "");
	    GUI.Label(new Rect (10, 10, 90, 20), "Notendanafn:");
	    username = GUI.TextField (new Rect (110, 10, REC_WIDTH / 2, 35), username, 20);
	    GUI.Label(new Rect (10, 50, 90, 20), "Lykilorð");
	    pass = GUI.PasswordField (new Rect (110, 50, REC_WIDTH / 2, 35), pass, "*"[0]);
	    bool registerButton = GUI.Button (new Rect (REC_WIDTH / 4, REC_HEIGHT / 2, REC_WIDTH / 2, 30), "Nýskrá í leik");
	    bool loginButton = GUI.Button (new Rect (REC_WIDTH / 4, REC_HEIGHT / 3, REC_WIDTH / 2, 30), "Innskrá í leik");

	    if (registerButton) 
	    {
	    	Debug.Log("button is clicked...");
	    	if(username == "")
	    	{
	    		username = "Leikmaður";	
	    	}
			    Debug.Log("network sendMessage");
			    StartCoroutine(RegisterUser(username, pass));
			    Invoke("loadNextLevel", 5);
		}

		if (loginButton) 
	    {
	    	Debug.Log("Register button is clicked...");
	    	if(username == "" | pass == "")
	    	{
	    		return;	
	    	}
			    StartCoroutine(GetUser(username, pass));
			    Invoke("loadNextLevel", 5);	  
		}
	    // End the group we started above. This is very important to remember!
	    GUI.EndGroup ();
    }

    public void loadNextLevel()
    {
    	DontDestroyOnLoad(gamestate.Instance);
        {
        	//Application.LoadLevel(Application.loadedLevel + 1);
		    gamestate.Instance.setName(username);
		    Application.LoadLevel("Add1.0");
        }
    }

  
}


