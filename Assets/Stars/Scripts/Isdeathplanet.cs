using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isdeathplanet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {}
		void OnCollisionEnter2D(Collision2D target){


			if (target.gameObject.name =="xingxing"||target.gameObject.name =="FixedStar"||target.gameObject.name=="img_3486"||target.gameObject.name =="img_3516"||target.gameObject.name=="player"||target.gameObject.name =="New Game Object"||target.gameObject.name =="Wall") { 
			GameObject.Find("Player").GetComponent<Isdeath>().isdeath = true;
			}  
		}
}
