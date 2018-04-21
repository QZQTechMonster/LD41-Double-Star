using UnityEngine;
using System.Collections;
public class AttractionForce : MonoBehaviour
{
    public LayerMask magneticLayers;
    public Vector3 position;
    public float radius;
    public float force;
    void FixedUpdate()
    {
        Collider2D[] colliders;
        Rigidbody2D rigidbody;
        colliders = Physics2D.OverlapCircleAll(transform.position + position, radius, magneticLayers);
        foreach (Collider2D collider in colliders)
        {
            print(collider.gameObject);
            rigidbody = collider.GetComponent<Rigidbody2D>();
            if (rigidbody == null)
            {
                continue;
            }
            rigidbody.AddForce(force * (transform.position - collider.transform.position).normalized);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + position, radius);
    }
}