using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NewObject : MonoBehaviour {

	public BoxCollider2D col;
	public double radius;
	public Vector2 target;
	public Vector2 startPosition;
	public Vector2 temp;
	public float speed; 
	public bool canMove;
	public bool hit;
	public static bool ready = true;
	public bool isInWrongPlace = false;
	public bool isInPlace = false;
	public bool trigger = false;
	public GameObject soundEffectsForDragging;
	public GameObject MainCameraObject;
	public bool hintCheck = true;
	public static float speedOfMove = 1.0f;
	public bool readyBool;

	public bool stoppari = true;


	

	//Shaking Variables
	public bool Shaking; 
	public float ShakeDecay;
	public float ShakeIntensity;   
	public Vector3 OriginalPos;
	public Quaternion OriginalRot;

	public static Costner t;
	
	//public int objectcounter = 0;

	//public AudioClip[] audioClip;


	// Frumstilling
	void Start () {

		soundEffectsForDragging = GameObject.FindGameObjectWithTag("MainCamera");
		MainCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		col = GetComponent<BoxCollider2D>();
		//radius = col.size.x / 2;
		radius = 3;
		target = transform.position;
		startPosition = target;
		temp = target;
		speed = 5f;
		readyBool = false;
		//hit = false;
		canMove = true;
		//Debug.Log("Start");
		t = gameObject.AddComponent<Costner>();
		t.NewScene();



	}

	Vector2 getTarget() {
		return target;
	}
}
