using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private bool isGrounded;
    void Update()
    {
        RaycastHit2D hitL = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.x/2, transform.position.y), Vector2.down, 0.4f, LayerMask.GetMask("Environment"));
        RaycastHit2D hitC = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, LayerMask.GetMask("Environment"));
        RaycastHit2D hitR = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y), Vector2.down, 0.4f, LayerMask.GetMask("Environment"));
        if (hitL || hitC || hitR) isGrounded = true;
        else isGrounded = false;
    }
    
    public ref bool GetStatus()
    {
        return ref isGrounded;
    }
}
