using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//using BasicConfigurations;

public class Trigger : DragScript 
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == this.gameObject.tag) // Ef dregið er á réttan stað þá þarf að logga rétt og spila Correct sound.
		{
			if(stoppari)
			{	

				trigger = true;
				target = other.transform.position; // Uppfærir staðsetningu á target við árekstur
				temp = other.transform.position;
				stoppari = false;

			}
		}
		else if(other.gameObject.tag != this.gameObject.tag && other.GetComponent<Trigger>() == null)
		{
			if(stoppari)
			{	
				isInWrongPlace = true;
				stoppari = false;
			}
		}
	}

	void OnTriggerExit2D()
	{
		stoppari = true;
		trigger = false;
		isInWrongPlace = false;
	}

}