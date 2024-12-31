using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MovementBehaviour
{

    private float jumpForce = 40f;
    private float queueJumpRemember = 0;
    private float groundedRemember = 0;
    private float airTime = 0;
    public override void start()
    {
        
    }

    public override void update(Rigidbody2D rb, float speed, ref bool isGrounded, Transform transform)
    {
        //A Jump is queued each time Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            queueJumpRemember = 0.15f;
        }
        if (queueJumpRemember > 0) queueJumpRemember -= Time.deltaTime;

        if (isGrounded)
        {
            groundedRemember = 0.1f;
        }
        if (groundedRemember > 0 && !isGrounded)
        {
            groundedRemember -= Time.deltaTime;
        }

        //If a Jump is queued and we are still in the queueJumpRemember time window AND we are still in the groundedRemember time window
        if (queueJumpRemember > 0 && groundedRemember > 0)
        {
            //groundedRemember is being reset to 0
            groundedRemember = 0;
            //velocity is added, this is t h e  j u m p
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //we are not on the ground if we jump
            isGrounded = false;
            //air time timer starts here
            airTime = Time.time;
        }

        //artificial gravity that always applies when in air
        if (!isGrounded)
        {
            rb.velocity = Utility.SetY(rb.velocity, rb.velocity.y - Utility.Slerp(jumpForce/200, jumpForce/50, (Time.time - airTime)));
        }
        //extra gravity that applies when we are in the air and let go of space
        if (!isGrounded && !Input.GetKey(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = Utility.SetY(rb.velocity, rb.velocity.y/4);
        }
    }
}
