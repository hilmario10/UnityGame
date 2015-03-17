using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectLokaverkefni.Models.Transfer;
using System.Text;

public class NetworkScript : MonoBehaviour {

	private string postURL = "http://localhost/Unity/Login/RegisterVIATablet/";
	private string GetUserURL = "http://localhost/Unity/Login/GetUser/";
	private string postPlayInfoURL = "http://localhost/Unity/Answer/AnswersToDB/";
	public static bool stopForOnlyOneCall = true;

 	public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm postForm = new WWWForm();
        postForm.AddField("name", username);
        postForm.AddField("password", password);
        var link = new WWW(postURL, postForm);

		string status = "";
        yield return link;
        if (link.error != null) 
		{
			status = link.error;
			print("There was an error retrieving the message from site: " + status);
		}
		else
		{
			UserModel usr = JsonConvert.DeserializeObject<UserModel>(link.text);
			Costner.userid = usr.userid;
			gamestate.Instance.setUserid(usr.userid);
		}
    }
 
 	public IEnumerator GetUser(string username, string password)
 	{
 		// Create new WWWForm 
 		WWWForm postForm = new WWWForm();
        postForm.AddField("name", username);
        postForm.AddField("password", password);
        var link = new WWW(GetUserURL, postForm);

		string status = "";
        yield return link;
        if (link.error != null) 
		{
			status = link.error;
			print("There was an error retrieving the message from site: " + status);
		}
		else
		{
			UserModel usr = JsonConvert.DeserializeObject<UserModel>(link.text);
			Costner.userid = usr.userid;
			gamestate.Instance.setUserid(usr.userid);
		}
 	}


 	public IEnumerator SendPlayInfo(List<AnswersModel> answers)
	{

		if(stopForOnlyOneCall)
		{
			stopForOnlyOneCall = false;	

	 		string json = JsonConvert.SerializeObject(answers);
			byte[] pData = Encoding.UTF8.GetBytes(json.ToCharArray());
					// Populate the post-form
			WWWForm postForm = new WWWForm();
			postForm.AddBinaryData ("playinfo", pData, "playinfo.json", "application/json");
			// Add form to a request
			WWW request = new WWW(postPlayInfoURL, postForm);

			// send post request
			yield return request;
			string status = "";
			status = "message sent"; // DEBUG
			if(request.error != null)
			{
				status = request.error; // DEBUG
				Debug.Log(status + " Errors damnit \n");
			}
			else
			{
				status = "server recieved message with no errors"; // DEBUG
				Debug.Log(status + " No Errors");
			}
			stopForOnlyOneCall = true;	
		}

	}
}
