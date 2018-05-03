using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void paused(){
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;
	}
}
