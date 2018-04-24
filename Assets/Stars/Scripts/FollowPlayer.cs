//Attached to 【Camera】 to make camera move with player
//Last Update: 4/22/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
	}
}
