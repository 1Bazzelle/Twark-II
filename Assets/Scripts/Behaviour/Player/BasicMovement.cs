using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MovementBehaviour
{
    public override void start()
    {
        
    }
    public override void update(Rigidbody2D rb, float speed, ref bool isGrounded, Transform transform)
    {
        rb.drag = 5;
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = new Vector2(movement.x * speed * 1.5f, rb.velocity.y);
    }
}
