using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeed : MonoBehaviour {

    [SerializeField] float maxSpeed;
    Rigidbody2D rgb;

	void Start()
	{
        rgb = GetComponent<Rigidbody2D>();
    }

	void LateUpdate()
	{
		if(rgb.velocity.magnitude > maxSpeed) {
            rgb.velocity = rgb.velocity.normalized * maxSpeed;
        }
		
	}
}
