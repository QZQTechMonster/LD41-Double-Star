//Attached to 【Shang】 to creat random move effect
//Last Update:4/22/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Range
{
	public float min ;
	public float max ;
}

public class RandomMove : MonoBehaviour {

	public Range SpeedRange;   // move speed of the object
	public Range DurationRange;  // duration of the object's movement 

	private Rigidbody2D Shang;
	private Vector2 movement;  // new random position of Shang
	private float timeLeft;  // left time of current duration 

	// Use this for initialization
	void Start () {
		Shang = GetComponent<Rigidbody2D> ();
		timeLeft = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			movement = new Vector2 (Random.Range (-2f, 2f), Random.Range (-2f, 2f));
			timeLeft += Random.Range (DurationRange.min, DurationRange.max);
		}
	}

	void FixedUpdate(){
		Shang.AddForce (movement * Random.Range (SpeedRange.min, SpeedRange.max));
	}
}
