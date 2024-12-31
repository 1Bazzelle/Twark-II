using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    public Rigidbody2D origin;
    public Rigidbody2D following;
    public float restDistance;
    public float maxOffset;
    private float offset;
    public float springStrength;
    public float damping;

    private Vector2 springDirection;

    private float originalSpringStrength;
    void Start()
    {
        springStrength = Mathf.Abs(springStrength);
        originalSpringStrength = springStrength;

        springDirection = Vector2.up;
        springDirection = springDirection.normalized;
    }

    void Update()
    {
        /*offset = (origin.position - following.position).magnitude - restDistance;
        if(offset <= maxOffset + 0.5f) 
            origin.AddForce(springDirection * ((-springStrength * offset) - (origin.velocity.y * damping)));
        if (offset > maxOffset) 
            origin.position = following.position + (springDirection * (restDistance + maxOffset));
        */
        Vector2 a = following.position - origin.position;
        Vector2 d = ((a * springDirection) / (a.magnitude * springDirection.magnitude) * a);
        offset = d.magnitude - restDistance;
        if (offset <= maxOffset + 0.5f)
            origin.AddForce(springDirection * ((-springStrength * offset) - (origin.velocity.y * damping)));
        if (offset > maxOffset)
            origin.position = following.position + (springDirection * (restDistance + maxOffset)) + (origin.position - (following.position + d));
    }

    public void AddForce(float force)
    {
        origin.AddForce(springDirection * force);
    }
    public float GetSpringStrength()
    {
        return springStrength;
    }
    public void SetSpringStrength(float newSpringStrength)
    {
        springStrength = Mathf.Abs(newSpringStrength);
    }
    public void ResetSpringStrength()
    {
        springStrength = originalSpringStrength;
    }
}
