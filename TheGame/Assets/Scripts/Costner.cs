using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectLokaverkefni.Models.Transfer;
using System.Text;

//Test
public class Costner : NetworkScript
{
	public static int userid;
	public static int gameid;
	public static int sceneid;
	public static int answerCorrect;
	public static bool oneAnsFill = true;
	public static DateTime timer;
	public static List<AnswersModel> ansList = new List<AnswersModel>();

	public void NewScene()
	{
 		//userid = 1;
 		gameid = 1;		// Comes from the game that gamedeveloper has done.
 		sceneid = Application.loadedLevel;

 		timer = DateTime.Now;
	}

	//Setur Correct í 100(rétt svar) og kallar á buildModel
 	public void RightAnswer(GameObject obj)
 	{
 		answerCorrect = 100;
 		BuildModelFromAnswer(obj);

 	} 

 	//Setur Correct í 0(rangt svar) og kallar á buildModel
 	public void WrongAnswer(GameObject obj)
 	{
 		answerCorrect = 0;
 		BuildModelFromAnswer(obj);
 	}

 	//Setur hvert svar i model og sendir til gatherInfo
 	public void BuildModelFromAnswer(GameObject obj)
 	{
 			AnswersModel ans = new AnswersModel();
 			//DefineTest dTest = new DefineTest();
 			DefineTest dTest = obj.GetComponent<DefineTest>(); 			
	 		//DefineObjects define = obj.GetComponent<DefineObjects>();

			TimeSpan span = DateTime.Now - timer;
			double sec = span.TotalSeconds;
			
			//ans.userid = userid;
			ans.gameid = gameid;
			ans.sceneid = sceneid;
			ans.typeid = (int)dTest.type;
			ans.objectid = dTest.Id; //(int)define.Object1Add;
			ans.correct = answerCorrect;
			ans.answerdate = timer;
			ans.answertime = (float)sec;
			ans.userid = gamestate.Instance.getUserid();
	 		GatherInfoFromModel(ans);	
 	}

 	//Tekur info og setur í model, sendir svo á buildJson
 	private void GatherInfoFromModel(AnswersModel answer)
 	{
 		 if(!ansList.Contains(answer))
 		 {
         	ansList.Add(answer);
 		 }

 	}

 	//tekur pakka af modelum og setur i json
 	public void BuildJsonObject()
 	{
 		StartCoroutine(SendPlayInfo(ansList));
 		ansList.Clear();
 	}

}