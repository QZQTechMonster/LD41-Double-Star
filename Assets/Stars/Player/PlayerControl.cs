using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField] float force;
    float forceX, forceY;

    Rigidbody2D rgb;

    void Start () {
        rgb = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        forceX = forceY = 0;
        if (Input.GetKey(KeyCode.W)) forceY = 1;
        if (Input.GetKey(KeyCode.S)) forceY = -1;
        if (Input.GetKey(KeyCode.A)) forceX = -1;
        if (Input.GetKey(KeyCode.D)) forceX = 1;
        rgb.AddForce(new Vector2(forceX, forceY).normalized * force * rgb.mass);
    }
}
