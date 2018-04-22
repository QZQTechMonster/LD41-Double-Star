
// attached to the player 

using UnityEngine;
using System.Collections;
public class AttractionForce : MonoBehaviour
{
    public LayerMask magneticLayers;
    public Vector3 position;
    public float radius;  // influence area
    public float force;  // the degree of gravity 
    void FixedUpdate()
    {
        Collider2D[] colliders;
        Rigidbody2D rigidbody;
        colliders = Physics2D.OverlapCircleAll(transform.position + position, radius, magneticLayers);  // Get all collider within the radius 
        foreach (Collider2D collider in colliders)  // Traverse every target within the radius
        {
//            print(collider.gameObject);
            rigidbody = collider.GetComponent<Rigidbody2D>();
            if (rigidbody == null)
            {
                continue;
            }
            rigidbody.AddForce(force * (transform.position - collider.transform.position).normalized);
        }
    }
    void OnDrawGizmosSelected()  // for scene debugging
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + position, radius);
    }
}