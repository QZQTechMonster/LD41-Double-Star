using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movieFirstLeft : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 0.02f;
	public float moveTime = 0.1f;
	public float maxTime = 150.0f;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			moveTime += 0.5f;
			transform.Translate (Vector3.left * moveSpeed);
			if (moveTime > maxTime) {
				transform.Rotate (0, 180, 0);
				moveTime = 0.1f;
			}
		}

	}
}
