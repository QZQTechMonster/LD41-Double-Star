//Attached to 【Arrow】to make it indicate the direction of Shang
//Last Update:4/22/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotate : MonoBehaviour {
	
	private GameObject Shang;
	private GameObject Player;
	private Vector2 dir;
	private float angle;

	// Use this for initialization
	void Start () {
		Shang = GameObject.Find ("Shang");
		Player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update (){
		dir = Shang.transform.position - Player.transform.position;
		angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90 , Vector3.forward);
	}
}
