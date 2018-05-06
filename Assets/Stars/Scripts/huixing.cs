//Attached to 【Player】 to generate and emit comet
//Latest Update: 5/7/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huixing : MonoBehaviour {

    public float interval = 5f;  // interval between two comet 
    public bool lifeCircleEnbale = true;  //if the comet has life circle
    public float duration = 3f;  // the duration of the comet
	public float speed = 250f;  // the speed of comet
    public float radius = 3f;  // the generate area of comet
    public float size = 0.03f;  //the size of the comet
    public float mass = 1f;  //the mass of the comet
    public Sprite cometSkin;  // the skin of the comet 

    private float timeLeft;
    public Vector3 pos;   // the random position for comet

	// Use this for initialization
	void Start () {
        timeLeft = interval;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            UpdatePos();
            CreateComet();
            timeLeft = interval;
        }
	}

    void CreateComet( )  // create a new comet and emit it 
    {
        GameObject comet = new GameObject();
        comet.transform.position = pos;
        InstantiateComet(comet);
        EmitComet(comet);
        StartCoroutine(lifeCircle(comet));
    }

    void InstantiateComet(GameObject comet)  // instantiate the new comet 
    {
        comet.transform.localScale = new Vector3(size, size, size);
        comet.AddComponent<SpriteRenderer>();
        comet.AddComponent<CircleCollider2D>();
        comet.AddComponent<Rigidbody2D>();
        comet.GetComponent<SpriteRenderer>().sprite = cometSkin;
        comet.GetComponent<Rigidbody2D>().mass = mass;
    }

    void EmitComet(GameObject comet)  // add an original force to a comet
    {
        Vector2 dir = this.transform.position - pos;  // get the direction of emitting
        comet.GetComponent<Rigidbody2D>().AddForce(dir.normalized * mass * speed);  // emit the comet
    }

    void UpdatePos()  // generate a new radom position for comet
    {
        pos = new Vector2(Random.Range(-radius, radius) + this.transform.position.x, Random.Range(-radius, radius) + this.transform.position.y); 
    }

    IEnumerator lifeCircle(GameObject comet)
    {
        yield return new WaitForSeconds(duration);
        Destroy(comet);
    }

}
