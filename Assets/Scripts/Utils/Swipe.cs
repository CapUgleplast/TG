using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour
{

    public float scrollSpeed;
    public float camMoveSpeed = 5.0f;
    public float bounceOffset = 7.0f;
    public Rect Pos;
    private Rigidbody rb;

    Vector3 newPosition = Vector3.zero;
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    newPosition = transform.position;
                    break;

                case TouchPhase.Moved:
                    var delta = touch.deltaPosition * scrollSpeed;
                    newPosition.x -= delta.x;
                    newPosition.z += delta.y;
                    newPosition.x = Mathf.Clamp(newPosition.x, Pos.xMin - bounceOffset, Pos.xMax + bounceOffset);
                    newPosition.z = Mathf.Clamp(newPosition.z, Pos.yMin - bounceOffset, Pos.yMax + bounceOffset);
                    transform.GetComponent<Rigidbody>().velocity = newPosition;
                    var velocity = new Vector3(-touch.deltaPosition.y, 0, touch.deltaPosition.x);
                    rb.velocity = velocity * scrollSpeed * camMoveSpeed;
                    break;
            }
        }

        var p = transform.position;
        
        transform.position = (Vector3.Lerp(p, newPosition, camMoveSpeed * Time.deltaTime));

        if (p.x > Pos.xMax)
        {
            rb.velocity = Vector3.zero;
            p.x = Pos.xMax - bounceOffset;
        }
        if (p.x < Pos.xMin)
        {
            rb.velocity = Vector3.zero;
            p.x = Pos.xMin + bounceOffset;
        }
        if (p.z > Pos.yMax)
        {
            rb.velocity = Vector3.zero;
            p.z = Pos.yMax - bounceOffset;
        }
        if (p.z < Pos.yMin)
        {
            rb.velocity = Vector3.zero;
            p.z = Pos.yMin + bounceOffset;
        }
        newPosition = p;
    }
}