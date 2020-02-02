using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public bool isLeft = false;
    public bool isHolding = false;
    public float speed = 1;
    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isHolding) {
            hand.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        } else {
            hand.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        float horizontal = (isLeft ? -Input.GetAxis("LeftHorizontal") : -Input.GetAxis("RightHorizontal"));
        float vertical = (isLeft ? Input.GetAxis("LeftVertical") : -Input.GetAxis("RightVertical"));
        float angle = (Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg); 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        // Debug.Log(Vector3.Distance(body.localPosition, transform.localPosition));
        



        float magnitude = Mathf.Clamp01(new Vector2(horizontal, vertical).magnitude);
        Debug.Log(magnitude);
        hand.rotation = transform.rotation;
        hand.transform.Translate (0 , magnitude * 0.7f, 0);
        // Translate the object
        // if(Vector3.Distance(body.localPosition, transform.localPosition) < 3)
            // transform.Translate (horizontal , vertical, 0);
    }
}
