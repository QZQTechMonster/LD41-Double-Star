using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_around : MonoBehaviour {
	public float radius;
	public Vector3 position;
	public LayerMask magneticLayers;
	public float angle = 0;
	public float angleSpeed = 5;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			float hudu = (angle / 180) * Mathf.PI;
			float cubeX = position.x + radius * Mathf.Cos (hudu);
			float cubeY = position.y + radius * Mathf.Sin (hudu);
			Vector3 v = this.transform.position;
			v.x = cubeX;
			v.y = cubeY;
			this.transform.position = v;
			angle += angleSpeed;
		}
	}
}
