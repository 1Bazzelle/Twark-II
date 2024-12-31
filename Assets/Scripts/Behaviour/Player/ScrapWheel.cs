using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ScrapWheel : MovementBehaviour
{
    private float rollSpeed;

    private float crouchWindow;
    private bool crouching;

    private float jumpForce = 3f;

    private Suspension sus1;
    private Suspension sus2;
    private float force = 27.5f;

    public override void start()
    {

        sus1 = GameObject.Find("Head").GetComponent<Suspension>();
        sus2 = GameObject.Find("Body").GetComponent<Suspension>();
    }
    public override void update(Rigidbody2D rb, float speed, ref bool isGrounded, Transform transform)
    { 
        rb.drag = 0.20f;
        rollSpeed = speed / 500;

        RaycastHit2D hit = Physics2D.Raycast(rb.transform.position, Vector2.down, 1, LayerMask.GetMask("Environment"));
        float slopeAngle = Mathf.Abs(Vector2.Angle(hit.normal, Vector2.down) - 180);

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3 (-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            

            rb.velocity = Utility.SetX(rb.velocity, rb.velocity.x - rollSpeed);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            rb.velocity = Utility.SetX(rb.velocity, rb.velocity.x + rollSpeed);
        }
        if (slopeAngle < 3 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isGrounded || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rb.drag = 1f;
            rb.velocity = Utility.SetX(rb.velocity, Utility.SnapValue(rb.velocity.x, 0, 0.1f));
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            crouchWindow = 0.1f;
        }
        if(crouchWindow > 0) crouchWindow -= Time.deltaTime;

        if(isGrounded && crouchWindow > 0)
        {
            crouchWindow = 0;
            crouching = true;
        }
        if (crouching && !Input.GetKey(KeyCode.LeftShift) || crouching && !isGrounded)
        {
            crouchWindow = 0;
            crouching = false;
        }

        if(crouching && Input.GetKeyDown(KeyCode.Space))
        {
            crouching = false;
            crouchWindow = 0;
            //sus1.SetSpringStrength(force * 10);
            sus2.SetSpringStrength(force * 10);


            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
        }
        
        if(!crouching && !isGrounded && rb.velocity.y < 0)
        {
            //sus1.ResetSpringStrength();
            sus2.ResetSpringStrength();
        }

        if (crouching)
        {
            sus1.AddForce(-force * 1.5f);
            sus2.AddForce(-force);
            rb.drag = 1.25f;
        }
    }
}

