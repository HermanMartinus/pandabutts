using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public DistanceJoint2D joint;
    static bool borked = false;
    public bool isMoving = false;
    public float stamina = 1;
    public float dkRate = 0.1f;

    void Awake()
    {
        joint = GetComponent<DistanceJoint2D>();
        borked = false;
    }


    void OnMouseDown()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    void OnMouseDrag()
    {
        if (borked)
            return;
        isMoving = true;
        joint.enabled = false;
        joint.connectedBody = null;
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
    }

    void OnMouseUp()
    {
        isMoving = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnJointBreak2D(Joint2D joint)
    {
        borked = true;
    }

    private void Update()
    {
        if (borked)
        {
            if(joint)
                joint.enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void FixedUpdate() {
        if (joint && joint.connectedBody != null) {
            stamina -= dkRate;

            if(stamina < 0) {
                borked = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(joint && collision.tag == "hold" && !isMoving) {
            joint.enabled = true;
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D() {

    }

}
