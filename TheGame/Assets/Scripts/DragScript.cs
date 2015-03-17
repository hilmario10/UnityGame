using UnityEngine;
using System.Collections;

public class DragScript : NewObject {

	public bool isOnLetter {get; set;}

	public Vector2 wp;
	public Vector2 orginalSize;
	public Vector2 HintOrginalSize;
	public Vector2 targetSize;
	public Color orginalColor;
	public float speedOfShake = 1.0f;
	public float amount = 1.0f;
	public GameObject[] hintObject;
	public bool oneCallToFinish = true;
	
	void Update () {



		wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if(Input.GetMouseButton(0) && withinBounds(wp, transform.position) && canMove && !isOnLetter) {
			//Debug.Log("rad " + radius);
			radius = 3;
			foreach (var item in FindObjectsOfType<DragScript>()) {
					item.canMove = false;
				}
			radius += 2 * radius;
			canMove = true; 
			transform.Translate(new Vector2(wp.x - transform.position.x, wp.y - transform.position.y));
			}
			if(!Input.GetMouseButton(0)) {
				// Kveikir á hreyfigetu GameObjecta í DragScript
				radius = col.size.x / 2;
				renderer.sortingOrder = 0; // GameOject fer á lægri flöt
				if(trigger && !isOnLetter)
				{
					ScaleUpObject();
					this.hit = true;
					stoppari = true;
					col.transform.position = target;
					//******* This piece of code has to be inserted into developers game.
					Debug.Log("RightAnswer");
					t.RightAnswer(this.gameObject);
					//******* piece of code ends.
					isOnLetter = true;
					this.GetComponent<Trigger>().enabled = false; // Þegar að GameObject er komið á réttan stað er það fast þar og óvirkt.
					setObjectsToMove();
				}
				else if(!trigger && isInWrongPlace) //Object dregið á rangann stað.  ****LOGGA ERRORA???***********
				// Hvada object er dregid a og hvada object er dregid...
				{
					DoShake();
					//******** This piece of code has to be inserted into developers game.
					Debug.Log("WrongAnswer");
					t.WrongAnswer(this.gameObject);
					////******** piece of code ends.
					stoppari = true;
					isInWrongPlace = false;
					col.transform.position = Vector2.MoveTowards(transform.position, startPosition, speedOfMove += 0.000001f);
					setObjectsToMove();

				}
				else	//Object dragid a ekkert object;
				{
					col.transform.position = Vector2.MoveTowards(transform.position, startPosition, speedOfMove += 0.000001f);
					setObjectsToMove();
					stoppari = true;
				}
				if(checkIfReady() && !readyBool)
				{
					readyBool = true;
					finishUpLevel();
				}	
		}
		// Þegar snerting hefst
		/*if(Input.touchCount > 0 && canMove && !isOnLetter) {
			Vector2 touchDeltaPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			if(withinBounds(touchDeltaPosition, transform.position)) {
				// Slekkur á hreyfigetu GameObjecta í DragScript
				foreach (var item in FindObjectsOfType<DragScript>()) {
					item.canMove = false;
				}
				canMove = true; // Kveikir á hreyfigetu GameObjects 
				radius = 2 * radius;
				renderer.sortingOrder = 1; // GameObject fer á hærri flöt 
				transform.Translate(new Vector2(touchDeltaPosition.x - transform.position.x, touchDeltaPosition.y - transform.position.y));
			} 
		}*/

		/*// Þegar snerting hættir
		if(Input.touchCount <= 0) {
			// Kveikir á hreyfigetu GameObjecta í DragScript
			radius = col.size.x / 2;
			renderer.sortingOrder = 0; // GameOject fer á lægri flöt
			if(trigger && !isOnLetter)
			{
				ScaleUpObject();
				this.hit = true;
				stoppari = true;
				col.transform.position = target;
				isOnLetter = true;
				this.GetComponent<Trigger>().enabled = false; // Þegar að GameObject er komið á réttan stað er það fast þar og óvirkt.
				setObjectsToMove();
			}
			else if(!trigger && isInWrongPlace) //Object dregið á rangann stað.  ****LOGGA ERRORA???***********
			// Hvada object er dregid a og hvada object er dregid...
			{
				DoShake();
				stoppari = true;
				isInWrongPlace = false;
				col.transform.position = Vector2.MoveTowards(transform.position, startPosition, speedOfMove += 0.000001f);
				setObjectsToMove();

			}
			else	//Object dragid a ekkert object;
			{
				col.transform.position = Vector2.MoveTowards(transform.position, startPosition, speedOfMove += 0.000001f);
				setObjectsToMove();
				stoppari = true;
			}
			if(checkIfReady() && !readyBool)
			{
				readyBool = true;
				finishUpLevel();
			}	
		}*/

		//Shaking stuff...
		if(ShakeIntensity > 0)
	    {
	        transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
	        transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
	                                  OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
	                                  OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
	                                  OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);
	 
	       ShakeIntensity -= ShakeDecay;
	    }
	    else if (Shaking)
	    {
	       Shaking = false; 
	    }
	}

	// Athugar hvort snerting sé innan marka
	bool withinBounds(Vector2 a, Vector2 b) {
		return System.Math.Abs(a.x - b.x) < radius && System.Math.Abs(a.y - b.y) < radius;
	}

	// Athugar hvort að öll GameObject eru kominn í stöðu til þess að klára borðið.
	public bool checkIfReady()
	{
		foreach (var item in FindObjectsOfType<DragScript>()) 
		{
			if(item.hit == false)
			{
				ready = false;
				break;
			}
			ready = true;
		}
		return ready;
	}

	//Leyfir öllum GameObjectum að hreyfa sig aftur
	public void setObjectsToMove()
	{
		foreach (var item in FindObjectsOfType<DragScript>()) {
			item.canMove = true;
			
		}
	}

	// Þegar level er búið þá klárum við það með því að save-a stöðu og loada næsta level með seinkun.
	public void finishUpLevel()
	{
		if(oneCallToFinish)
		{
			oneCallToFinish = false;
			Debug.Log("Greetings from finishUpLevel");
			//Costner sendList = gameObject.AddComponent<Costner>();
			//sendList.BuildJsonObject();
			Invoke("LoadWhenFinished", 4);
			 //StartCoroutine(gamestate.Instance.loadNextLevel());
		}
	}
	
	public void LoadWhenFinished()
	{
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.loadNextLevel();
	}

	public void ScaleUpObject()
	{
		orginalSize = this.transform.localScale;
		this.transform.localScale *= 1.2f;
		orginalColor = this.renderer.material.color;
		this.renderer.material.color = Color.green;
		Invoke("ChangeBackScale", 0.5f);
	}

	public void ChangeBackScale()
	{
		this.transform.localScale = orginalSize;
		this.renderer.material.color = orginalColor;
	}

	public void DoShake()
	{
	    OriginalPos = transform.position;
	    OriginalRot = transform.rotation;
	    ShakeIntensity = 0.3f;
	    ShakeDecay = 0.02f;
	    Shaking = true;
	}  

}