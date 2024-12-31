using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody2D rb;
    private GroundCollision groundCol;
    private Transform transform;
    private List<MovementBehaviour> movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCol = GetComponent<GroundCollision>();
        transform = GetComponent<Transform>();

        movement = new List<MovementBehaviour>();
        movement.Add(new ScrapWheel());
        
        if (movement.Count != 0)
        {
            foreach (MovementBehaviour p in movement)
            {
                p.start();
            }
        }
    }

    void Update()
    {
        if (movement.Count != 0)
        {
            foreach (MovementBehaviour p in movement)
            { 
                p.update(rb, speed, ref groundCol.GetStatus(), transform);
            }
        }
    }
}

