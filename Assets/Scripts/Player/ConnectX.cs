using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectX : MonoBehaviour
{
    public Rigidbody2D rb;
    private float offset = 0.125f;
    private Vector2 destination;
    private float counter;
    private bool current;
    void Start()
    {
        current = false;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A)) current = true;
        else if (Input.GetKey(KeyCode.D)) current = false;

        if (current)
        {
            destination = new Vector2(rb.position.x - offset, transform.position.y);
        }
        else
        {
            destination = new Vector2(rb.position.x + offset, transform.position.y);
        }

        transform.position = destination;
    }
}
