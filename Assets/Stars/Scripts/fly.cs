using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour {
	public Vector3 target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other){
		
		double targetX = Random.Range (-20f, 20f);
		double targetY = Random.Range (-20f, 20f);
		target.x = (float)targetX;
		target.y = (float)targetY;

		if (other.gameObject.name =="hell") { 

			if (!(target.Equals (other.gameObject.name == "FixedStar")||target.Equals (other.gameObject.name == "img_3486")||target.Equals (other.gameObject.name == "xingxing")||target.Equals (other.gameObject.name == "hell")||target.Equals (other.gameObject.name == "img_3516"))) {
				gameObject.transform.position = target;
			}
			        }  
		    }
}