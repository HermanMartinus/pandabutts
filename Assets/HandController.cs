using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public bool isLeft = false;
    public float speed = 1;
    public Transform body;
    // public Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = (isLeft ? Input.GetAxis("LeftHorizontal") : Input.GetAxis("RightHorizontal")) * Time.deltaTime * speed;
        float vertical = (isLeft ? Input.GetAxis("LeftVertical") : -Input.GetAxis("RightVertical")) * Time.deltaTime * speed;

        Debug.Log(Vector3.Distance(body.localPosition, transform.localPosition));
        
 
        // Translate the object
        // if(Vector3.Distance(body.localPosition, transform.localPosition) < 3)
            transform.Translate (horizontal , vertical, 0);
    }
}
