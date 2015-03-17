using UnityEngine;
using System.Collections;
using System;

public class DefineTest : MonoBehaviour {

	//private int objId;
	private GameTypes objName;	

	public int Name;
	public int Id;

	public enum GameTypes{
		None 				= 0,
		FormGame			= 1,
		ColorGame 			= 2,
		SizeGame 			= 3,
		Addition_1to10 		= 4,

	}

	public GameTypes type;

	public GameTypes Type
	{
		get
		{
			return objName;
		}
		set
		{
			objName = type;
		}
	}
}
