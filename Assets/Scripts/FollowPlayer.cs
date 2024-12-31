using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class FollowPlayer : MonoBehaviour
{
    private UnityEngine.Rigidbody2D target;
    public float horizontalOffset = 1;
    public float verticalOffset = 2.8f;

    float interpolationX = 300f;
    float interpolationY = 300f;

    float distanceX;
    float distanceY;

    bool closeInX = false;
    bool closeInY = false;
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<UnityEngine.Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalMovement();
        VerticalMovement();
    }
    void HorizontalMovement()
    {
        float temp = transform.position.x - horizontalOffset;
        distanceX = Mathf.Abs(temp - target.position.x) ;

        if (distanceX > 0)
        {
            closeInX = true;
        }
        if (closeInX)
        {
            interpolationX = Mathf.Clamp(--interpolationX, 150, 300);
            if (target.position.x > temp)
            {
                temp += (distanceX / interpolationX);
            }
            if (target.position.x < transform.position.x)
            {
                temp -= (distanceX / interpolationX);
            }
        }
        if (distanceX == 0)
        {
            closeInX = false;
            interpolationX = 300f;
        }
        transform.position = Utility.SetX(transform.position, temp + horizontalOffset);
    }
    void VerticalMovement()
    {
        float temp = transform.position.y - verticalOffset;
        distanceY = Mathf.Abs(temp - target.position.y);

        if (distanceY > 0)
        {
            closeInY = true;
        }
        if (closeInY)
        {
            interpolationY = Mathf.Clamp(--interpolationY, 150, 300);
            if (target.position.y > temp)
            {
                temp += (distanceY / interpolationY);
            }
            if (target.position.y < transform.position.y)
            {
                temp -= (distanceY / interpolationY);
            }
        }
        if (distanceY == 0)
        {
            closeInY = false;
            interpolationY = 300f;
        }
        transform.position = Utility.SetY(transform.position, temp + verticalOffset);
    }
}