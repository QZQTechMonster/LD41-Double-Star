//Attached to 【FixedStart】 to emit its child stars
//Latest Update: 4/22/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extension
{

    public static Vector2 Rotate( this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}

public class Emit : MonoBehaviour {

    public int childNum = 3;  // the number of childs that you wany to emit each time
    public bool lifeCircle = false;
    public float durationTime = 6f;  // the life duration time of child star
    public float interval = 10f;  // the interval between two emit event
    public float childSize = 0.15f;  // the child's local size according to its parent
    public float childMass = 0.1f;   // the child's mass 
    public float childSpeed = 30f;  // the original speed of emitted childs
    public float angle = 30f;   // the angle of each child

    private GameObject player;
    private float timeLeft;
    private GameObject[] childs;


    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        timeLeft = interval;
    }

    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            List<GameObject> childs;
            childs = creatChild();
            emitChild(childs);
            StartCoroutine(lifeCircle_destroy(lifeCircle, childs));
            timeLeft = interval;
        }
    }

    IEnumerator lifeCircle_destroy(bool enable, List<GameObject> childs)   // destroy the child object if the life circle was enabled
    {
        yield return new WaitForSeconds(durationTime);
        if (enable)
        {
            for (int i = 0; i < childs.Count; i++)
            {
                if (childs[i].name != this.name)
                    Destroy(childs[i].gameObject);
            }
        }
    }

    List<GameObject> creatChild( )   // create the child of the fixed star 
    {
        List<GameObject> childs = new List<GameObject>();
        for (int i = 0; i < childNum; i++)
        {
            childs.Add(InstantiateChild());
        }
        return childs;
    }

    GameObject InstantiateChild( )  // instantiate child
    {
        GameObject child = new GameObject();
        child.transform.SetParent(this.transform);
        child.transform.localScale = new Vector3(1, 1, 1) * childSize;  //set size
        child.transform.position = this.transform.position;  //set position
        child.AddComponent<SpriteRenderer>();
        child.AddComponent<CircleCollider2D>();
        child.AddComponent<Rigidbody2D>();
        child.GetComponent<SpriteRenderer>().sprite = this.GetComponentInParent<SpriteRenderer>().sprite;  //set sprite
        child.GetComponent<SpriteRenderer>().color = this.GetComponentInParent<SpriteRenderer>().color;  // set color
        child.GetComponent<Rigidbody2D>().mass = childMass;
        return child;
    }

    void emitChild(List<GameObject> childs) // emit childs
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector2 dir_rotate = new Vector2(dir.x, dir.y);
        for (int i = 0; i < childs.Count; i++)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), childs[i].GetComponent<Collider2D>());  // ignore the collision between child and its parent
            for (int j = i + 1; j < childs.Count; j++)
                Physics2D.IgnoreCollision(childs[i].GetComponent<Collider2D>(), childs[j].GetComponent<Collider2D>());  // ignore the collision between every child
            childs[i].GetComponent<Rigidbody2D>().AddForce(dir_rotate.Rotate( ( i -1 ) * angle ) * childMass * childSpeed);  // rotate and emit
        }
    }
}
