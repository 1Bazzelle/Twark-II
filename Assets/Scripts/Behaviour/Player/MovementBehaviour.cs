using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MovementBehaviour
{
    public abstract void start();
    public abstract void update(Rigidbody2D rb, float speed, ref bool isGrounded, Transform transform);
    
}
